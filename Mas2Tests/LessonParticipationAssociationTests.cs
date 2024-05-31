using Xunit;
using Mas2.Models;
using Mas2.Validators;
using System;
using System.Linq;

namespace Mas2Tests
{
    public class LessonParticipationAssociationTests
    {
        private Course _course;
        private Lesson _lesson;
        private Teacher _teacher;
        private Participation _participation;

        public LessonParticipationAssociationTests()
        {
            _course = new Course("Test Course");
            _lesson = new Lesson("Math", 60, _course);
            _teacher = new Teacher("John", "Doe", "john.doe@example.com");
            _participation = new Participation(_teacher, _lesson, "absent", DateTime.Now);
        }

        [Fact]
        public void AddParticipationToLesson_ShouldAddParticipationToLessonAndLessonToParticipation()
        {
            // Act
            _lesson.AddParticipation(_participation);

            // Assert
            Assert.Contains(_participation, _lesson.Participations);
            Assert.Equal(_lesson, _participation.Lesson);
        }

        [Fact]
        public void RemoveParticipationFromLessonAndTeacherFromParticipation_ShouldRemoveParticipationFromLessonAndLessonFromParticipationAndTeacherFromParticipationAndParticipationFromTeacher()
        {
            // Arrange
            _lesson.AddParticipation(_participation);

            // Act
            _lesson.RemoveParticipation(_participation);

            // Assert
            Assert.DoesNotContain(_participation, _lesson.Participations);
            Assert.Null(_participation.Lesson);
            Assert.DoesNotContain(_participation, _teacher.Participations);
            Assert.Null(_participation.Teacher);
        }

        [Fact]
        public void AddingSameParticipationTwice_ShouldNotDuplicateAssociation()
        {
            // Act
            _lesson.AddParticipation(_participation);
            _lesson.AddParticipation(_participation);

            // Assert
            Assert.Single(_lesson.Participations.Where(p => p == _participation));
        }

        [Fact]
        public void RemovingParticipationNotAssociatedWithLesson_ShouldNotThrowException()
        {
            // Act and Assert
            var exception = Record.Exception(() => _lesson.RemoveParticipation(_participation));
            Assert.Null(exception);
        }
    }
}
