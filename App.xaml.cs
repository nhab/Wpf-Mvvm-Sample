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

            MainWindow mainWindow = new MainWindow();
            this.MainWindow = mainWindow;
            mainWindow.Show();


            //LoginView myUserControl = new LoginView();
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Content = myUserControl;
            //mainWindow.Show();

        }
    }
}
