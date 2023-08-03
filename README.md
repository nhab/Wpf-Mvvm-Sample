# WpfMvvm
A WPF MVVM To log in and Enter People Data

## To create a WPF MVMM Project:
- Create a WPF Project in the Visual Studio
- Check to have these Reference Added To your Project:
 PresentationCore, PresentationFramework, WindowsBase
- Create (or use) your Main Window.xaml inside the Views folder in your project
- Create a "Models" Folder in your project and add a data model like this:
```
class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
```
- Create a ViewModels Folder in the project and add a ViewModelBase Class as the parent of all the ViewModels in the project:

```
  public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
```
- Create a CommandClass like this:
  (It is nothing special . It is a class that implements the **ICommand** interface)

```
 public class RelayCommand: ICommand
    {   
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute = execute;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
```
- Create your ViewModel Classe in the ViewModes folder, like this:
  Each of these ViewModels will be bound to a Window (view)
```
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
        }
    }
  ```
Note that Each Command in this class, Handles operations of the window events.


  
