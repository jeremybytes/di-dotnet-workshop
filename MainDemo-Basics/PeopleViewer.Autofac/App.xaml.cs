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

namespace PeopleViewer.Autofac
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
            var builder = new ContainerBuilder();

            // DATA READER TYPE OPTION #1 - No Decorator
            //builder.RegisterType<ServiceReader>().As<IPersonReader>()
            //    .SingleInstance();

            // DATA READER TYPE OPTION #2 - With Decorator
            builder.RegisterType<ServiceReader>().Named<IPersonReader>("reader")
                .SingleInstance();
            builder.RegisterDecorator<IPersonReader>(
                (c, inner) => new CachingReader(inner), fromKey: "reader");


            // OTHER TYPES OPTION #1 - Automatic Registration
            //builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            // OTHER TYPES OPTION #2 - Explicit Registration
            builder.RegisterType<MainWindow>().InstancePerDependency();
            builder.RegisterType<PeopleViewModel>().InstancePerDependency();

            Container = builder.Build();
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Resolve<MainWindow>();
        }
    }
}
