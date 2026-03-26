using Zadanie_2.Domain.Enums;

namespace Zadanie_2.Domain.Equipment;

public abstract class Equipment
{
    public int Id { get; }
    public string Name { get; }
    public EquipmentStatus Status { get; private set; }

    protected Equipment(int id, string name)
    {
        Id = id;
        Name = name;
        Status = EquipmentStatus.Available;
    }

    public void MarkAsAvailable()
    {
        Status = EquipmentStatus.Available;
    }

    public void MarkAsRented()
    {
        Status = EquipmentStatus.Rented;
    }

    public void MarkAsUnavailable()
    {
        Status = EquipmentStatus.Unavailable;
    }

    public override string ToString()
    {
        return $"{GetType().Name} | Id: {Id} | Name: {Name} | Status: {Status}";
    }
}