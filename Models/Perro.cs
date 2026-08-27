namespace MascotasApi.Models;

public class Perro : Mascota
{
    public string Raza { get; set; }

    public override string Tipo
    {
        get { return "Perro"; }
    }
}
