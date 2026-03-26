using Zadanie_2.Domain.Enums;

namespace Zadanie_2.Domain.Users;

public class Employee : User
{
    public string Department { get; }
    public string Position { get; }

    public Employee(int id, string firstName, string lastName, string department, string position)
        : base(id, firstName, lastName, UserType.Employee)
    {
        Department = department;
        Position = position;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Department: {Department} | Position: {Position}";
    }
}