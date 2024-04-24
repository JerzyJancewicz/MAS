using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Course
    {
        public Student student = new Student(); // Student 1 - * Course
        public List<Lesson> lessons = new List<Lesson>();
    }
}
