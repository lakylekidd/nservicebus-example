using System;

namespace Platform
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Particular Service Platform Launcher";
            Particular.PlatformLauncher.Launch();
        }
    }
}
