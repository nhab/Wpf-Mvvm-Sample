# WpfMvvm
A WPF MVVM To log in and Enter People Data

To create a WPF MVMM Project:
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
- Create a ViewModels Folder in the project and add a ViewModelBase Class as the parent of al the ViewModels in the project:

```
  public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //protected void NotifyPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        public void OnPropertyChanged(string property) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
```
