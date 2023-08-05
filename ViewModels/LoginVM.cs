using System;
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
        public ICommand CloseWindowCommand { get; }

        public event EventHandler CloseRequested;

        public LoginVM()
        {
            user = new User();
            user.UserName = "admin"; // default value
            user.Password = "1234";
            LoginCommand = new RelayCommand((param) => LoggedIn(user.UserName,user.Password));
            CloseWindowCommand = new RelayCommand((param) => CloseWindow());
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
                mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                mainWindow.Show();
                CloseWindow();
            }
            else
                MessageBox.Show($"Log-in not successful as {parameter1} by password:{parameter2}." );
        }

        private void CloseWindow()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}