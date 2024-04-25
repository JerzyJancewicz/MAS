using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Course
    {
        private HashSet<Lesson> lessons = new HashSet<Lesson>();
        private string Title;
        private string? Description;

        public Course(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public Course(string title)
        {
            Title = title;
        }
    }
}
