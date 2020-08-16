using Ninject;
using PeopleLibrary;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System;

namespace PeopleApplication
{
    public partial class App : Application
    {
        IKernel Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            Application.Current.MainWindow = Container.Get<MainWindow>();
            Application.Current.MainWindow.Show();
        }

        // Ninject - Auto-Registration
        private void ConfigureContainer()
        {
            Container = new StandardKernel();

            var assembly = typeof(DefaultPersonFormatter).Assembly;

            var formatterTypes = from type in assembly.GetTypes()
                                 where !type.IsAbstract &&
                                       type.Name.EndsWith("Formatter") &&
                                       !type.Name.StartsWith("Composite")
                                 select type;

            foreach(Type type in formatterTypes)
            {
                Container.Bind<IPersonFormatter>().To(type).InTransientScope();
            }
        }

        // Ninject - Configuration in Code
        //private void ConfigureContainer()
        //{
        //    Container = new StandardKernel();
        //    Container.Bind<IPersonFormatter>().To<DefaultPersonFormatter>().InTransientScope();
        //    Container.Bind<IPersonFormatter>().To<FamilyNamePersonFormatter>().InTransientScope();
        //    Container.Bind<IPersonFormatter>().To<GivenNamePersonFormatter>().InTransientScope();
        //    Container.Bind<IPersonFormatter>().To<FullNamePersonFormatter>().InTransientScope();
        //}
    }
}
