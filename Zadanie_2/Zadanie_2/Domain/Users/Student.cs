using Zadanie_2.Domain.Enums;

namespace Zadanie_2.Domain.Users;

public class Student : User
{
    public string StudentNumber { get; }
    public string Faculty { get; }

    public Student(int id, string firstName, string lastName, string studentNumber, string faculty)
        : base(id, firstName, lastName, UserType.Student)
    {
        StudentNumber = studentNumber;
        Faculty = faculty;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Student No: {StudentNumber} | Faculty: {Faculty}";
    }
}