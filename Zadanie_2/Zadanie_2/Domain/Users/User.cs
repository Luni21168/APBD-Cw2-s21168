using Zadanie_2.Domain.Enums;

namespace Zadanie_2.Domain.Users;

public abstract class User
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public UserType UserType { get; }

    protected User(int id, string firstName, string lastName, UserType userType)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UserType = userType;
    }

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return $"{UserType} | Id: {Id} | {FullName}";
    }
}