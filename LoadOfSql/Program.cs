using System;
using ApplicationJournal;
using DomainModel.Repositories;
using DomainModel.Repositories.SuperTypes;
using Infrastructure.Data.EF.Repositories;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace LoadOfSql
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = UnityConfig.BuildUnityContainer();
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(container.Resolve<Form1>());
        }       
    }
    public static class UnityConfig
    {
        public static IUnityContainer BuildUnityContainer()
        {           
            var currentContainer = new UnityContainer();
            //services
            currentContainer.RegisterType<IEmployeeService, EmployeeService>();
            currentContainer.RegisterType<IRecordService, RecordService>();
            currentContainer.RegisterType<IUserService, UserService>();

            //repos
            currentContainer.RegisterType<ISignRepository, SignRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(GlobalSettings.ConnectionString));
            currentContainer.RegisterType<IEmployeeRepository, EmployeeRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(GlobalSettings.ConnectionString));
            currentContainer.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(GlobalSettings.ConnectionString));
            currentContainer.RegisterType<IRecordRepository, RecordRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(GlobalSettings.ConnectionString));
            currentContainer.RegisterType<ITemplateRepository, TemplateRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(GlobalSettings.ConnectionString));

            return currentContainer;
        }
    }
}
