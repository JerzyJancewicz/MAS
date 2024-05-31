using Mas2.Models;
using Xunit;

namespace Mas2Tests
{
    public class GradeStudentAssociationTests
    {
        [Fact]
        public void AddGradeToStudent_ShouldAddUniqueGradeToStudentAndAddStudentToGrade()
        {
            // Arrange
            var student = new Student("John", "Doe");
            var grade = new Grade("Math", "A", "Excellent", student);

            // Act
            student.AddGrade(grade);

            // Assert
            Assert.Equal(grade, student.GetGradeByLessonName("Math"));
            Assert.Equal(student, grade.Student);
        }

        [Fact]
        public void AddStudentToGrade_ShouldAddStudentToGradeAndAddUniqueGradeToStudent()
        {
            // Arrange
            var student = new Student("John", "Doe");
            var grade = new Grade("Math", "A", "Excellent", student);

            // Act
            grade.AddStudent(student);

            // Assert
            Assert.Equal(student, grade.Student);
            Assert.Equal(grade, student.GetGradeByLessonName("Math"));
        }
    }
}
