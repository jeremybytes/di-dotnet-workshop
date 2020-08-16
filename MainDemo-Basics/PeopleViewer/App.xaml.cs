using PeopleViewer.Logging;
using PeopleViewer.Presentation;
using PersonReader.CSV;
using PersonReader.Decorators;
using PersonReader.Service;
using PersonReader.SQL;
using System;
using System.IO;
using System.Windows;

namespace PeopleViewer
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ComposeObjects();
            Application.Current.MainWindow.Show();
        }

        private static void ComposeObjects()
        {
            var wrappedReader = new ServiceReader();
            var reader = new CachingReader(wrappedReader);
            var viewModel = new PeopleViewModel(reader);
            Application.Current.MainWindow = new MainWindow(viewModel);
        }
    }
}
