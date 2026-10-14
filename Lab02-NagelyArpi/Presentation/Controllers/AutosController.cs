using Lab02_NagelyArpi.Models;
using Lab02_NagelyArpi.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Lab02_NagelyArpi.Controllers
    {
    [ApiController]
    [Route("api/[controller]")]
    public class AutosController : ControllerBase
    {
        private static List<Auto<Persona>> baseDatosAutos = new List<Auto<Persona>>()
        {
            new Auto<Persona>(
                "ABC-123", 
                "Arequipa", 
                "Toyota", 
                "Yaris", 
                2022, 
                new Persona(1, "Nagely", "12345678", "nagely@email.com", "987654321")
            )
        };

        // GET: api/autos
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(baseDatosAutos);
        }

        // GET: api/autos/{placa}
        [HttpGet("{placa}")]
        public IActionResult GetByPlaca(string placa)
        {
            var auto = baseDatosAutos.FirstOrDefault(a => a.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if (auto == null) return NotFound($"El auto con placa {placa} no fue encontrado.");
            return Ok(auto);
        }

        // POST: api/autos
        [HttpPost]
        public IActionResult Post([FromBody] Auto<Persona> nuevoAuto)
        {
            if (baseDatosAutos.Any(a => a.Placa.Equals(nuevoAuto.Placa, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest("Ya existe un auto registrado con la misma placa.");
            }
            baseDatosAutos.Add(nuevoAuto);
            return CreatedAtAction(nameof(GetByPlaca), new { placa = nuevoAuto.Placa }, nuevoAuto);
        }

        // PUT: api/autos/{placa}
        [HttpPut("{placa}")]
        public IActionResult Put(string placa, [FromBody] Auto<Persona> autoActualizado)
        {
            var autoExistente = baseDatosAutos.FirstOrDefault(a => a.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if (autoExistente == null) return NotFound($"El auto con placa {placa} no existe.");

            autoExistente.SedeTransito = autoActualizado.SedeTransito;
            autoExistente.Marca = autoActualizado.Marca;
            autoExistente.Modelo = autoActualizado.Modelo;
            autoExistente.Anio = autoActualizado.Anio;
            autoExistente.Propietario = autoActualizado.Propietario;

            return Ok(autoExistente);
        }

        // PATCH: api/autos/{placa}
        [HttpPatch("{placa}")]
        public IActionResult Patch(string placa, [FromBody] AutoPatchDto cambios)
        {
            var autoExistente = baseDatosAutos.FirstOrDefault(a => a.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if (autoExistente == null) return NotFound($"El auto con placa {placa} no existe.");

            if (!string.IsNullOrEmpty(cambios.SedeTransito))
            {
                autoExistente.SedeTransito = cambios.SedeTransito;
            }

            if (!string.IsNullOrEmpty(cambios.EmailPropietario) && autoExistente.Propietario != null)
            {
                autoExistente.Propietario.Email = cambios.EmailPropietario;
            }

            return Ok(autoExistente);
        }

        // DELETE: api/autos/{placa}
        [HttpDelete("{placa}")]
        public IActionResult Delete(string placa)
        {
            var autoExistente = baseDatosAutos.FirstOrDefault(a => a.Placa.Equals(placa, StringComparison.OrdinalIgnoreCase));
            if (autoExistente == null) return NotFound($"El auto con placa {placa} no existe.");

            baseDatosAutos.Remove(autoExistente);
            return NoContent();
        }
    }
}

