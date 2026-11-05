namespace Lessons9.Exceptions
{
    public class StudentHasDisciplinesException: Exception
    {
        public StudentHasDisciplinesException(int studentId) : base($"У студента {studentId} есть дисциплины") { }
    }
}
