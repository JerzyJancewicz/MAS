using Mas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2.Validators
{
    public class ParticipationValidator
    {
        public static void ValidateLesson(Lesson? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Topic can not be null");
            }
        }
        public static void ValidateTeacher(Teacher? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Topic can not be null");
            }
        }
        public static void ValidateDate(DateTime? value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("Topic can not be null");
            }
            if (value.HasValue)
            {
                if (!DateTime.IsLeapYear(value.Value.Year))
                {
                    throw new ArgumentException("Not valid date");
                }
            }
        }
        public static void ValidateStatus(string? value)
        {
            List<string> statusList = new List<string>();
            statusList.Add("absent");
            statusList.Add("present");
            statusList.Add("exempt");

            if (value == null)
            {
                throw new ArgumentNullException("Topic can not be null");
            }
            if (!statusList.Contains(value.ToLower().Trim()))
            {
                throw new ArgumentException("There is no such a status");
            }
        }
    }
}
