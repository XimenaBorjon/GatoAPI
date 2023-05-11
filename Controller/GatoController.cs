using GatoAPI.Models;
using GatoAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GatoAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatoController : ControllerBase
    {
        private readonly Sistem21GatoContext context;
        GatoRepository<Jugador> gatoRepository;
        public GatoController(Sistem21GatoContext context)
        {
            this.context = context;
            gatoRepository = new GatoRepository<Jugador>(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(gatoRepository.GetAll());
        }

        [HttpPost]
        public  IActionResult Post(Jugador jugador)
        {
            try
            {
                jugador.Id = 0;
                jugador.PartidasGanadas = 0;
                gatoRepository.Insert(jugador);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(Jugador jugador)
        {
            var j = gatoRepository.Get(jugador.Id);
            if (j == null)
            {
                return NotFound();
            }

            try
            {
              
                j.Id = jugador.Id;
                j.Nombre = jugador.Nombre;
                j.PartidasGanadas = jugador.PartidasGanadas + 1;
                gatoRepository.Update(j);
                return Ok();

            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
