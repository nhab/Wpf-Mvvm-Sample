using System;
using System.Collections.Generic;
using System.Windows;
using WpfAppMvvm.Models;
using WpfAppMvvm.ViewModels;

namespace WpfAppMvvm.Views
{
  
    public partial class MainWindow : Window
    {
        public List<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Closing += MainWindow_Cllosing;
            List<Student> Students = new List<Student>();
            Students = new List<Student>
            {
                new Student("Dave", 21, DateTime.Now.Subtract(new TimeSpan(100, 1, 1, 1))),
                new Student("Bill", 21, DateTime.Now.Subtract(new TimeSpan(300, 1, 1, 1))),
                new Student("deri", 21, DateTime.Now.Subtract(new TimeSpan(400, 1, 1, 1)))
            };

            DataContext = new StudentVM(Students);
        }
        private void MainWindow_Cllosing(object sender,System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
