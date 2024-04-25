using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Participation
    {
        private Lesson Lesson;
        private Teacher Teacher;

        private DateTime Date;
        private string Status;

        public Participation(Lesson lesson, Teacher teacher, string status, DateTime date)
        {
            Lesson = lesson;
            Teacher = teacher;
            Status = status;
            Date = date;
        }
    }
}
