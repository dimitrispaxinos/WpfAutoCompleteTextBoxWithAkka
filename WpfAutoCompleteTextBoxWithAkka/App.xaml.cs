using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Akka.Actor;

namespace WpfAutoCompleteTextBoxWithAkka
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Create Main ActorSystem of the Application
            ActorData.ActorSystem = ActorSystem.Create("ActorSystem");

            base.OnStartup(e);
        }
    }
}
