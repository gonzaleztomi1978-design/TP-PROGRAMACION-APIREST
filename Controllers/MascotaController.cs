using MascotasApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MascotasApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MascotaController : ControllerBase
{
    private static List<Mascota> mascotas = new List<Mascota>()
    {
        new Perro { Id = 1, Nombre = "Firulais", Edad = 5, Raza = "Labrador" },
        new Gato { Id = 2, Nombre = "Luna", Edad = 3, Color = "Blanco" },
        new Perro { Id = 3, Nombre = "Rocky", Edad = 8, Raza = "Bulldog" },
        new Gato { Id = 4, Nombre = "Michi", Edad = 10, Color = "Naranja" }
    };

    [HttpGet]
    public IActionResult ObtenerTodas()
    {
        List<object> resultado = new List<object>();

        foreach (Mascota mascota in mascotas)
        {
            resultado.Add(mascota);
        }

        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public IActionResult ObtenerPorId(int id)
    {
        Mascota mascota = BuscarPorId(id);

        if (mascota == null)
        {
            return NotFound("No existe una mascota con el Id " + id + ".");
        }

        return Ok(mascota);
    }

    private Mascota BuscarPorId(int id)
    {
        foreach (Mascota mascota in mascotas)
        {
            if (mascota.Id == id)
            {
                return mascota;
            }
        }

        return null;
    }
}
