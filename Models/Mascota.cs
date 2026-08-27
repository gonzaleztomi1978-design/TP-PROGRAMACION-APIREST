namespace MascotasApi.Models;

public abstract class Mascota
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public int Edad { get; set; }

    public abstract string Tipo { get; }
}
