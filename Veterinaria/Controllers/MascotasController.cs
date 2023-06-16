using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.Data;
using Veterinaria.Models;
using static Veterinaria.Data.VeterinariaDBContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veterinaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotasController : ControllerBase
    {
        private VeterinariaDBContext _veterinariaContext;
        public MascotasController(VeterinariaDBContext veterinariaContext)
        {
            _veterinariaContext = veterinariaContext;
        }
        // GET: api/<MascotasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _veterinariaContext.Mascotas.ToListAsync());
        }

        // GET api/<MascotasController>/5
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetMascota([FromRoute] int id)
        {
            var mascota = await _veterinariaContext.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            return Ok(mascota);
        }


        // POST api/<MascotasController>
        [HttpPost]
       
        public async Task<IActionResult> AddMascota(Mascotas.mascota mascota )
        {
            var _mascota=new Mascotas.Mascota();
            _mascota.Nombre = mascota.Nombre;
            _mascota.FecNac = mascota.FecNac;
            _mascota.Genero = mascota.Genero;
            _mascota.Especie = mascota.Especie;
            _mascota.Raza = mascota.Raza;
            _mascota.DuenoId = mascota.DuenoId;
            await _veterinariaContext.AddAsync(_mascota);
            await _veterinariaContext.SaveChangesAsync();

            return Ok(mascota);
        }

        // PUT api/<MascotasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMascota([FromRoute] int id, Mascotas.mascota mascota)
        {
            var _mascota = await _veterinariaContext.Mascotas.FindAsync(id);
            if (_mascota != null)
            {
                _mascota.Nombre = mascota.Nombre;
                _mascota.FecNac = mascota.FecNac;
                _mascota.Genero = mascota.Genero;
                _mascota.Especie = mascota.Especie;
                _mascota.Raza = mascota.Raza;
                _mascota.DuenoId = mascota.DuenoId;

                await _veterinariaContext.SaveChangesAsync();
                return Ok(_mascota);
            }
            return NotFound();
        }

        // DELETE api/<MascotasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMascota(int id)
        {
            var _mascota = await _veterinariaContext.Mascotas.FindAsync(id);
            if (_mascota != null)
            {
                _veterinariaContext.Remove(_mascota);
                _veterinariaContext.SaveChanges();
                return Ok(_mascota);
            }
            return NotFound();
        }
    }
}
