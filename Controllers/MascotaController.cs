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

    private static int proximoId = 5;

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

    [HttpPost("perro")]
    public IActionResult AgregarPerro(MascotaRequest datos)
    {
        if (EstaVacio(datos.Nombre))
        {
            return BadRequest("El nombre es obligatorio.");
        }

        if (datos.Edad < 0)
        {
            return BadRequest("La edad no puede ser negativa.");
        }

        if (EstaVacio(datos.Raza))
        {
            return BadRequest("La raza es obligatoria.");
        }

        Perro perro = new Perro
        {
            Id = proximoId,
            Nombre = datos.Nombre,
            Edad = datos.Edad,
            Raza = datos.Raza
        };

        mascotas.Add(perro);
        proximoId = proximoId + 1;

        return CreatedAtAction(nameof(ObtenerPorId), new { id = perro.Id }, perro);
    }

    [HttpPost("gato")]
    public IActionResult AgregarGato(MascotaRequest datos)
    {
        if (EstaVacio(datos.Nombre))
        {
            return BadRequest("El nombre es obligatorio.");
        }

        if (datos.Edad < 0)
        {
            return BadRequest("La edad no puede ser negativa.");
        }

        if (EstaVacio(datos.Color))
        {
            return BadRequest("El color es obligatorio.");
        }

        Gato gato = new Gato
        {
            Id = proximoId,
            Nombre = datos.Nombre,
            Edad = datos.Edad,
            Color = datos.Color
        };

        mascotas.Add(gato);
        proximoId = proximoId + 1;

        return CreatedAtAction(nameof(ObtenerPorId), new { id = gato.Id }, gato);
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

    private bool EstaVacio(string texto)
    {
        if (texto == null)
        {
            return true;
        }

        if (texto.Trim() == "")
        {
            return true;
        }

        return false;
    }
}
