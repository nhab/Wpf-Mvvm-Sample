using System;
using System.Collections.Generic;
using System.Windows;
using WpfAppMvvm.Models;

namespace WpfAppMvvm.Views
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Cllosing;
            List<Student> Students = new List<Student>();
            Students.Add(new Student("Dave", 21, DateTime.Now.Subtract(new TimeSpan(100, 1, 1, 1))));
            Students.Add(new Student("Bill", 21, DateTime.Now.Subtract(new TimeSpan(300, 1, 1, 1))));
            Students.Add(new Student("deri", 21, DateTime.Now.Subtract(new TimeSpan(400, 1, 1, 1))));
            DataContext = Students;
        }
        private void MainWindow_Cllosing(object sender,System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
