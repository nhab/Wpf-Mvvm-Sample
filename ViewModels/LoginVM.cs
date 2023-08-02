using System.Windows;
using System.Windows.Input;
using WpfAppMvvm.Commands;
using WpfAppMvvm.Models;


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
            MessageBox.Show($"Logged in successfull as {parameter1} by password:{parameter2}");
        }
    }
}