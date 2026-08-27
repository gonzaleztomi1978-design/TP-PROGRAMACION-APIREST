namespace MascotasApi.Models;

public class Gato : Mascota
{
    public string Color { get; set; }

    public override string Tipo
    {
        get { return "Gato"; }
    }
}
