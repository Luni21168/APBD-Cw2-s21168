using Zadanie_2.Domain.Equipment;
using Zadanie_2.Domain.Enums;

namespace Zadanie_2.Repositories;

public class EquipmentRepository
{
    private readonly List<Equipment> _equipment = new();

    public void Add(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    public Equipment? GetById(int id)
    {
        return _equipment.FirstOrDefault(e => e.Id == id);
    }

    public IReadOnlyList<Equipment> GetAll()
    {
        return _equipment;
    }

    public IReadOnlyList<Equipment> GetAvailable()
    {
        return _equipment.Where(e => e.Status == EquipmentStatus.Available).ToList();
    }
}