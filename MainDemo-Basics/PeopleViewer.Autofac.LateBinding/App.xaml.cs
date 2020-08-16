using Common;
using PeopleViewer.Presentation;
using PersonReader.Service;
using PersonReader.Decorators;
using PersonReader.CSV;
using System.Windows;
using System;
using PersonReader.SQL;
using Autofac;
using Autofac.Features.ResolveAnything;
using Microsoft.Extensions.Configuration;
using Autofac.Configuration;
using System.Runtime.Loader;

namespace PeopleViewer.Autofac.LateBinding
{
    public partial class App : Application
    {
        IContainer Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile("autofac.json");

            var configuration = configBuilder.Build();
            LoadAssembly(configuration);

            var module = new ConfigurationModule(configuration);
            var builder = new ContainerBuilder();
            builder.RegisterModule(module);

            builder.RegisterType<MainWindow>().InstancePerDependency();
            builder.RegisterType<PeopleViewModel>().InstancePerDependency();

            Container = builder.Build();
       }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Resolve<MainWindow>();
        }

        private static void LoadAssembly(IConfigurationRoot configuration)
        {
            // This is a helper method to load an assembly from the file system.
            // With .NET Core, if the assembly is not loaded, Autofac cannot find
            // it. The same is true when using Type.GetType with a fully-qualified 
            // assembly name.
            var section = configuration.GetSection("defaultAssembly");
            var assemblyName = section.Value + ".dll";
            var assemblyPath = AppDomain.CurrentDomain.BaseDirectory + assemblyName;
            AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
        }
    }
}
