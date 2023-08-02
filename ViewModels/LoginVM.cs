using System.Windows;
using System.Windows.Input;
using WpfAppMvvm.Commands;
using WpfAppMvvm.Models;
using WpfAppMvvm.Views;

namespace WpfAppMvvm.ViewModels
{

    public class LoginVM : ViewModelBase
    {
        private User user;
        public ICommand LoginCommand { get; }
        public LoginVM()
        {
            user = new User();
            LoginCommand = new RelayCommand((param) => LoggedIn(user.UserName,user.Password));
        }

        public string UserName
        {
            get => user.UserName;
            set
            {
                user.UserName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        public string Password
        {
            get => user.Password;
            set
            {
                user.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private void LoggedIn(object parameter1, object parameter2)
        {
            if(parameter1!=null && parameter2!=null && parameter1.ToString()=="admin" && parameter2.ToString()=="1234")
             {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }else
                MessageBox.Show($"Log-in not successful as {parameter1} by password:{parameter2}." );
        }
    }
}