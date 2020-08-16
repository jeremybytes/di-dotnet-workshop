using Common;
using Ninject;
using PeopleViewer.Presentation;
using PersonReader.Service;
using PersonReader.Decorators;
using PersonReader.CSV;
using System.Windows;
using System;
using PersonReader.SQL;

namespace PeopleViewer.Ninject
{
    public partial class App : Application
    {
        IKernel Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            Container = new StandardKernel();
            Container.Bind<IPersonReader>().To<CachingReader>()
                .InSingletonScope()
                .WithConstructorArgument<IPersonReader>(Container.Get<ServiceReader>());
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Get<MainWindow>();
        }
    }
}
