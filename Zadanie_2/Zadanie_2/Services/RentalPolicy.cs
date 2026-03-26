using Zadanie_2.Domain.Enums;
using Zadanie_2.Domain.Users;

namespace Zadanie_2.Services;

public class RentalPolicy
{
    public int GetUserLimit(User user)
    {
        return user.UserType switch
        {
            UserType.Student => 2,
            UserType.Employee => 5,
            _ => 0
        };
    }
}