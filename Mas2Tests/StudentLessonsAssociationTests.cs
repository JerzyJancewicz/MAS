using Xunit;
using Mas2.Models;
using Mas2.Validators;
using System.Linq;

namespace Mas2Tests
{
    public class StudentLessonAssociationTests
    {
        private Course _course;
        private Lesson _lesson1;
        private Lesson _lesson2;
        private Student _student;

        public StudentLessonAssociationTests()
        {
            _course = new Course("Test Course");
            _lesson1 = new Lesson("Math", 60, _course);
            _lesson2 = new Lesson("Science", 45, _course);
            _student = new Student("Doe", "John");
        }

        [Fact]
        public void AddLessonToStudent_ShouldAddLessonToStudentAndStudentToLesson()
        {
            // Act
            _student.AddLesson(_lesson1);

            // Assert
            Assert.Contains(_lesson1, _student.Lessons);
            Assert.Contains(_student, _lesson1.Students);
        }

        [Fact]
        public void RemoveLessonFromStudent_ShouldRemoveLessonFromStudentAndStudentFromLesson()
        {
            // Arrange
            _student.AddLesson(_lesson1);

            // Act
            _student.RemoveLesson(_lesson1);

            // Assert
            Assert.DoesNotContain(_lesson1, _student.Lessons);
            Assert.DoesNotContain(_student, _lesson1.Students);
        }

        [Fact]
        public void AddStudentToLesson_ShouldAddStudentToLessonAndLessonToStudent()
        {
            // Act
            _lesson1.AddStudent(_student);

            // Assert
            Assert.Contains(_student, _lesson1.Students);
            Assert.Contains(_lesson1, _student.Lessons);
        }

        [Fact]
        public void RemoveStudentFromLesson_ShouldRemoveStudentFromLessonAndLessonFromStudent()
        {
            // Arrange
            _lesson1.AddStudent(_student);

            // Act
            _lesson1.RemoveStudent(_student);

            // Assert
            Assert.DoesNotContain(_student, _lesson1.Students);
            Assert.DoesNotContain(_lesson1, _student.Lessons);
        }

        [Fact]
        public void AddingSameLessonTwice_ShouldNotDuplicateAssociation()
        {
            // Act
            _student.AddLesson(_lesson1);
            _student.AddLesson(_lesson1);

            // Assert
            Assert.Single(_student.Lessons.Where(l => l == _lesson1));
            Assert.Single(_lesson1.Students.Where(s => s == _student));
        }

        [Fact]
        public void RemovingLessonNotAssociatedWithStudent_ShouldNotThrowException()
        {
            // Act and Assert
            var exception = Record.Exception(() => _student.RemoveLesson(_lesson1));
            Assert.Null(exception);
        }

        [Fact]
        public void RemovingStudentNotAssociatedWithLesson_ShouldNotThrowException()
        {
            // Act and Assert
            var exception = Record.Exception(() => _lesson1.RemoveStudent(_student));
            Assert.Null(exception);
        }
    }
}
