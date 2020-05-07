using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MOTReminder.Business;
using MOTReminder.Business.DTO;
using MOTReminder.Utils;
using MOTReminder.Utils.RegistrationFormatter;
using System;
using System.Threading.Tasks;

namespace MOTReminder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<Context>();
            //        context.Database.EnsureCreated();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while seeding the database.");
            //    }
            //}

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder => 
                {
                    builder.RegisterType<UK>().As<IRegistrationFormatter>().PropertiesAutowired();
                    builder.RegisterType<RegistrationHelper>().As<IRegistrationHelper>();
                    builder.RegisterType<RegistrationService>().As<IRegistrationService>();
                    builder.RegisterType<UKVDVehicleService>().As<IVehicleService>()
                        .EnableInterfaceInterceptors().InterceptedBy(typeof(VehicleServiceInterceptor));
                    builder.RegisterType<MOTService>().As<IMOTService>();
                    builder.RegisterType<VehicleServiceInterceptor>().AsSelf();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>();
                });
    }

    public class VehicleServiceInterceptor : IInterceptor
    {
        private readonly IRegistrationHelper _helper;

        public VehicleServiceInterceptor(IRegistrationHelper helper)
        {
            _helper = helper;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            var method = invocation.MethodInvocationTarget;
            if (method.Name != nameof(IVehicleService.GetDetailsByAsync)) return;

            invocation.ReturnValue = InterceptAsync((Task<Vehicle>)invocation.ReturnValue);
        }

        private async Task<Vehicle> InterceptAsync(Task<Vehicle> task)
        {
            Vehicle result = await task.ConfigureAwait(false);
            result.MOTExpiry = DateTime.Now.AddDays(_helper.DaysBeforeExpiryToNotify).AddSeconds(10);
            return result;
        }
    }
}
