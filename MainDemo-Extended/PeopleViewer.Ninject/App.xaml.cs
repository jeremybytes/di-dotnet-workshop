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
            Container.Bind<ServiceReaderUri>()
                .ToConstant(new ServiceReaderUri("http://localhost:9874"));

            Container.Bind<IPersonReader>().To<ServiceReader>()
                .InSingletonScope();
        }

        private void ComposeObjects()
        {
            Application.Current.MainWindow = Container.Get<MainWindow>();
        }
    }
}
