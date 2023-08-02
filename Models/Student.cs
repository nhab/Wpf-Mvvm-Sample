using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfAppMvvm.Models
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime JoiningDate { get; set; }

        public Student() { }
        public Student(string name, int age, DateTime joiningDate)
        {
            Name = name;
            Age = age;
            JoiningDate = joiningDate;
        }
    }
}