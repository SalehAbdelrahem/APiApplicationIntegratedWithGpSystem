using System.Web.Http;
using IntegratorWithGp.Services.Iservices.ICustomerServices;
using IntegratorWithGp.Services.Iservices.IVendorService;
using IntegratorWithGp.Services.IServices.IItemServices;
using IntegratorWithGp.Services.IServices.IItemVendorServices;
using IntegratorWithGp.Services.IServices.IPurchasingServices;
using IntegratorWithGp.Services.IServices.IReceivingTransactionEntityServices;
using IntegratorWithGp.Services.IServices.ISales;
using IntegratorWithGp.Services.IServices.ISalesTransactionServices;
using IntegratorWithGp.Services.Services.CustomerServices;
using IntegratorWithGp.Services.Services.ItemServices;
using IntegratorWithGp.Services.Services.ItemVendorServices;
using IntegratorWithGp.Services.Services.PurchasingServices;
using IntegratorWithGp.Services.Services.ReceivingTransactionEntityServices;
using IntegratorWithGp.Services.Services.Sales;
using IntegratorWithGp.Services.Services.SalesTransactionServices;
using IntegratorWithGp.Services.Services.VendorService;
using IntegratorWithGP.App_Start;
using Unity;

namespace IntegratorWithGP
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<ISalesTransactionService, SalesTransactionService>();
            container.RegisterType<IReceivingTransactionEntityService, ReceivingTransactionEntityService>();
            container.RegisterType<ICustomerService, CustomerService>();
            container.RegisterType<IVendorService, VendorService>();
            container.RegisterType<IItemService, ItemService>();
            container.RegisterType<IItemVendorService, ItemVendorService>();
            container.RegisterType<IPurchasingService, PurchasingService>();
            container.RegisterType<ISalesService, SalesService>();
            config.DependencyResolver = new UnityResolver(container);

            #region BackGroundJob 
            //// Set up the Quartz scheduler
            //IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result; 
            //scheduler.Start().Wait();
            //// Define the job and tie it to the TwiceDailyJob class
            //IJobDetail job = JobBuilder.Create<TwiceDailyJob>().WithIdentity("twiceDailyJob", "group1").Build();
            //// Create a CronTrigger 0 * * ? * * *  every minits ,0 0 8,20 * * ?  to fire at 8 AM and 8 PM every day 
            //ITrigger cronTrigger = TriggerBuilder.Create().WithIdentity("twiceDailyTrigger", "group1").WithCronSchedule("0 * * ? * * * ").Build();
            //    // Cron expression: At 08:00 AM and 08:00 PM every day;
            //    // Schedule the job using the scheduler
            // scheduler.ScheduleJob(job, cronTrigger).Wait();
            #endregion
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
