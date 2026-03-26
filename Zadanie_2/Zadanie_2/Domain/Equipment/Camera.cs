namespace Zadanie_2.Domain.Equipment;

public class Camera : Equipment
{
    public int Megapixels { get; }
    public bool HasOpticalZoom { get; }

    public Camera(int id, string name, int megapixels, bool hasOpticalZoom)
        : base(id, name)
    {
        Megapixels = megapixels;
        HasOpticalZoom = hasOpticalZoom;
    }

    public override string ToString()
    {
        return base.ToString() + $" | MP: {Megapixels} | Optical Zoom: {HasOpticalZoom}";
    }
}