using System;
using System.Collections.Generic;
using System.Text;

namespace BestPractices
{
    public class School
    {
        public int id { get; set; }
        public string Name { get; set; }
        public Course Courses { get; set; }
    }

    public  class Course
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
}
