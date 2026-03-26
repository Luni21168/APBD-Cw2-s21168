using Zadanie_2.Domain.Rentals;

namespace Zadanie_2.Repositories;

public class RentalRepository
{
    private readonly List<Rental> _rentals = new();

    public void Add(Rental rental)
    {
        _rentals.Add(rental);
    }

    public Rental? GetById(int id)
    {
        return _rentals.FirstOrDefault(r => r.Id == id);
    }

    public Rental? GetActiveByEquipmentId(int equipmentId)
    {
        return _rentals.FirstOrDefault(r => r.EquipmentId == equipmentId && r.IsActive);
    }

    public IReadOnlyList<Rental> GetAll()
    {
        return _rentals;
    }

    public IReadOnlyList<Rental> GetActiveByUserId(int userId)
    {
        return _rentals.Where(r => r.UserId == userId && r.IsActive).ToList();
    }

    public IReadOnlyList<Rental> GetOverdue(DateTime today)
    {
        return _rentals.Where(r => r.IsOverdue(today)).ToList();
    }
}