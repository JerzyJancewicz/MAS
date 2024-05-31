using Mas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mas2Tests
{
    public class LessonCourseAssociationTests
    {
        [Fact]
        public void LessonCannotExistWithoutCourse()
        {
            // Arrange
            var course = new Course("Test Course");
            var lesson = new Lesson("Test Topic", 60, course);

            // Act
            lesson.RemoveCourse();

            // Assert
            Assert.Null(lesson.Course);
        }

        [Fact]
        public void CourseCanExistWithoutLesson()
        {
            // Arrange
            var course = new Course("Test Course");

            // Assert
            Assert.Empty(course.Lessons);
        }
    }

}
