using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfAppMvvm.Commands;
using WpfAppMvvm.Models;


namespace WpfAppMvvm.ViewModels
{
    public class StudentVM : ViewModelBase
    {
        private Student _student;
        private ObservableCollection<Student> _students;
        private ICommand _SubmitCommand;

        public Student Student
        {
            get=> _student;
            
            set{
                _student = value;
                OnPropertyChanged("Student");
            }
        }
        public ObservableCollection<Student> Students
        {
            get=>_students;
            
            set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }
        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.Submit()
                    , (_student) => { return ((Student != null)&&(Student as Student).Name != null) && ((Student as Student).Age != 0); });
                }
                return _SubmitCommand;
            }
        }
        public StudentVM(List<Student> students = null)
        {
            Student = new Student();
            if(students!=null)
            Students = new ObservableCollection<Student>(students);
            Students.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Students_CollectionChanged);
        }
        //Whenever new item is added to the collection, it explicitly calls notify property changed  
        void Students_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Students");
        }
        private void Submit()
        {
            Student.JoiningDate = DateTime.Today.Date;
            Students.Add(Student);
            Student = new Student();
        }
    }
}