using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Notifications.Infrastructure;
using Notifications.Services;
using NServiceBus;
using NServiceBus.ObjectBuilder.MSDependencyInjection;

namespace Notifications
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
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddTransient<EmailService>();
            services.AddTransient<SMSService>();
            services.AddTransient<Func<NotificationType, INotificationService>>(serviceProvider => key =>
            {
                switch (key)
                {
                    case NotificationType.Email:
                        return serviceProvider.GetService<EmailService>();
                    case NotificationType.SMS:
                        return serviceProvider.GetService<SMSService>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            // services.AddSingleton<IPaymentRepository, PaymentRepository>();
            services.AddSingleton(sp => endpoint);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Configure NServiceBus
            var endpointConfiguration = new EndpointConfiguration("Assignment.Notifications");
            var transport = endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.SendFailedMessagesTo("failed");
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            endpointConfiguration.SendHeartbeatTo("Particular.ServiceControl");
            var metrics = endpointConfiguration.EnableMetrics();
            metrics.SendMetricDataToServiceControl("Particular.Monitoring", TimeSpan.FromMilliseconds(500));

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

            app.UseCors(options => options.AllowAnyOrigin());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
