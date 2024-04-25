using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Models
{
    public class Lesson
    {
        private static HashSet<Lesson> Tasks = new HashSet<Lesson>();
        private static List<string> Topics = new List<string>();

        // associations
        private Teacher Teacher;
        private Course Course;
        private Participation Participation;
        private string Topic;
    }
}
