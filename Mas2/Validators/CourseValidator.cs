using Mas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Validators
{
    public class CourseValidator
    {
        public static void ValidateLessn(Lesson lesson)
        {
            if (lesson == null)
            {
                throw new ArgumentNullException("Lesson can not be a null");
            }
        }
    }
}
