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
        public void AddLessonToCourse_ShouldAddLessonToCourseAndAddCourseToLesson()
        {
            // Arrange
            var course = new Course("Test Course");
            var course2 = new Course("Test Course 2");
            var lesson = new Lesson("Test Topic", 60, course);
            var lesson2 = new Lesson("Test Topic 2", 59, course);

            // Act
            course2.AddLesson(lesson2);

            // Assert
            Assert.Contains(lesson2, course2.Lessons); 
            Assert.Equal(course2, lesson2.Course);
        }

        [Fact]
        public void CreateLesson_ShouldAddCourseToLessonAndLessonToCourse()
        {
            // Arrange
            var course = new Course("Test Course");

            // Act
            var lesson = new Lesson("Test Topic", 60, course);

            // Assert
            Assert.Contains(lesson, course.Lessons);
            Assert.Equal(course, lesson.Course);
        }

        [Fact]
        public void AddCourseToLesson_ShouldAddCourseToLessonAndLessonToCourse()
        {
            // Arrange
            var course = new Course("Test Course");
            var course2 = new Course("Test Course2");
            var lesson = new Lesson("Test Topic", 60, course);

            // Act
            lesson.AddCourse(course2);

            // Assert
            Assert.Contains(lesson, course2.Lessons);
            Assert.Equal(course2, lesson.Course);
        }

        [Fact]
        public void RemoveCourseFromLesson_ShouldRemoveLessonFromCourseAndCourseFromLessonAndAllAssociationsThatAreAssociatedWithinLesson()
        {
            // Arrange
            var course = new Course("Test Course");
            var student = new Student("John", "Doe");
            var teacher = new Teacher("John", "Doe", "john.doe@example.com");
            var lesson = new Lesson("Test Topic", 60, course);
            var participation = new Participation(teacher, lesson, "absent", DateTime.Now);
            lesson.AddStudent(student);

            // Act
            lesson.RemoveCourse();

            // Assert
            Assert.DoesNotContain(lesson, course.Lessons);
            Assert.Null(lesson.Course);
            Assert.DoesNotContain(student, lesson.Students);
            Assert.DoesNotContain(participation, lesson.Participations);
            Assert.Null(participation.Lesson);
            Assert.Null(participation.Teacher);
        }


        [Fact]
        public void RemoveLessonFromCourse_ShouldRemoveCourseFromLessonAndLessonFromCourseAndAllAssociationsThatAreAssociatedWithinLesson()
        {
            // Arrange
            var course = new Course("Test Course");
            var student = new Student("John", "Doe");
            var teacher = new Teacher("John", "Doe2", "john.doe@example.com");
            var lesson = new Lesson("Test Topic", 60, course);
            var participation = new Participation(teacher, lesson, "absent", DateTime.Now);
            lesson.AddStudent(student);

            // Act
            course.RemoveLesson(lesson);

            // Assert
            Assert.Null(lesson.Course); 
            Assert.DoesNotContain(lesson, course.Lessons); 
            Assert.DoesNotContain(student, lesson.Students); 
            Assert.DoesNotContain(participation, lesson.Participations); 
            Assert.Null(participation.Lesson);
            Assert.Null(participation.Teacher);
        }
    }
}
