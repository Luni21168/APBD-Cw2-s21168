namespace Zadanie_2.Domain.Equipment;

public class Projector : Equipment
{
    public int BrightnessLumens { get; }
    public string Resolution { get; }

    public Projector(int id, string name, int brightnessLumens, string resolution)
        : base(id, name)
    {
        BrightnessLumens = brightnessLumens;
        Resolution = resolution;
    }

    public override string ToString()
    {
        return base.ToString() + $" | Brightness: {BrightnessLumens} lm | Resolution: {Resolution}";
    }
}