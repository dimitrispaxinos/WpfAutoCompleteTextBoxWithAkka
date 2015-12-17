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
