using Lessons9.Interfaces;
using Lessons9.Models;
using Lessons9.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace LessonsTests
{
    public class StudentsServiceTests
    {
        [Fact]
        public void CanDeleteStudent_NoDisciplines_ReturnsTrue()
        {
            // Arrange
            var student = new Student
            {
                Disciplines = new List<Discipline>()
            };
            // Act
            bool result = StudentService.CanDeleteStudent(student);
            // Assert
            Assert.True(result);

        }

        [Fact]
        public void CanDeleteStudent_WithDisciplines_ReturnsFalse()
        {
            // Arrange
            var student = new Student
            {
                Disciplines = new List<Discipline> { new Discipline { Id = 1 }}
            };
            // Act
            bool result = StudentService.CanDeleteStudent(student);
            // Assert
            Assert.False(result);
        }

    }
}
