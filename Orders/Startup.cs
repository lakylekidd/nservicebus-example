using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;
using NServiceBus.ObjectBuilder.MSDependencyInjection;
using Orders.Infrastructure;
using System;

namespace Orders
{
    public class Startup
    {
        IEndpointInstance endpoint;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton(sp => endpoint);

            // Configure NServiceBus
            var endpointConfiguration = new EndpointConfiguration("Assignment.Orders");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.SendFailedMessagesTo("failed");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            endpointConfiguration.SendHeartbeatTo("Assignment.ServiceControl");
            var metrics = endpointConfiguration.EnableMetrics();
            metrics.SendMetricDataToServiceControl("Assignment.Monitoring", TimeSpan.FromMilliseconds(500));

            UpdateableServiceProvider container = null;
            endpointConfiguration.UseContainer<ServicesBuilder>(customizations =>
            {
                customizations.ExistingServices(services);
                customizations.ServiceProviderFactory(sc =>
                {
                    container = new UpdateableServiceProvider(sc);
                    return container;
                });
            });

            endpoint = Endpoint.Start(endpointConfiguration).GetAwaiter().GetResult();

            return container;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
