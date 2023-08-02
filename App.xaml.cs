using System.Windows;
using System.Windows.Controls;
using WpfAppMvvm.Views;

namespace WpfAppMvvm
{
    public partial class App : Application
    {


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginView myUserControl = new LoginView();
            Window window = new Window();
            window.Width = 400;
            window.Height = 600;
            window.Content = myUserControl;
            window.Show();

        }
    }
}
