using Xunit;
using Mas2.Models;
using Mas2.Validators;
using System;
using System.Linq;

namespace Mas2Tests
{
    public class TeacherParticipationAssociationTests
    {
        private Course _course;
        private Lesson _lesson;
        private Teacher _teacher;
        private Participation _participation;

        public TeacherParticipationAssociationTests()
        {
            _course = new Course("Test Course");
            _lesson = new Lesson("Math", 60, _course);
            _teacher = new Teacher("John", "Doe", "john.doe@example.com");
            _participation = new Participation(_teacher, _lesson, "absent", DateTime.Now);
        }

        [Fact]
        public void AddParticipationToTeacher_ShouldAddParticipationToTeacherAndTeacherToParticipation()
        {
            // Act
            _teacher.AddParticipation(_participation);

            // Assert
            Assert.Contains(_participation, _teacher.Participations);
            Assert.Equal(_teacher, _participation.Teacher);
        }

        [Fact]
        public void RemoveParticipationFromTeacher_ShouldRemoveParticipationFromTeacherAndTeacherFromParticipation()
        {
            // Arrange
            _teacher.AddParticipation(_participation);

            // Act
            _teacher.RemoveParticipation(_participation);

            // Assert
            Assert.DoesNotContain(_participation, _teacher.Participations);
            Assert.Null(_participation.Teacher);
        }

        [Fact]
        public void AddingSameParticipationTwice_ShouldNotDuplicateAssociation()
        {
            // Act
            _teacher.AddParticipation(_participation);
            _teacher.AddParticipation(_participation);

            // Assert
            Assert.Single(_teacher.Participations.Where(p => p == _participation));
        }

        [Fact]
        public void RemovingParticipationNotAssociatedWithTeacher_ShouldNotThrowException()
        {
            // Act and Assert
            var exception = Record.Exception(() => _teacher.RemoveParticipation(_participation));
            Assert.Null(exception);
        }
    }
}
