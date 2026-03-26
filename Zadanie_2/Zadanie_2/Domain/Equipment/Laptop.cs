namespace Zadanie_2.Domain.Equipment;

public class Laptop : Equipment
{
    public string Processor { get; }
    public int RamGb { get; }

    public Laptop(int id, string name, string processor, int ramGb)
        : base(id, name)
    {
        Processor = processor;
        RamGb = ramGb;
    }

    public override string ToString()
    {
        return base.ToString() + $" | CPU: {Processor} | RAM: {RamGb} GB";
    }
}