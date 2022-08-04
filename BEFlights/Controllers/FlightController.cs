using BEFlights.Domain.IServices;
using BEFlights.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BEFlights.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        // Guardar vuelos
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Flight flight)
        {
            try
            {
                var validateExistence = await _flightService.ValidateExistence(flight);
                if (validateExistence) // Valida la existencia del mismo numero de vuelo registrado
                {
                    return BadRequest(new { message = "El numero de vuelo " + flight.FlightNumber + " ya existe!" });
                }
                await _flightService.SaveFlight(flight);

                return Ok(new { messsage = "Vuelo registrado con exito!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Obtener todos los vuelos
        [Route("getAllFlights")]
        [HttpGet]
        public async Task<IActionResult> GetAllFlights()
        {
            try
            {
                var listFlights = await _flightService.GetAllFlights();
                return Ok(listFlights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Obtener todos los vuelos con el mismo origen
        [Route("origin/{origin}")]
        [HttpGet]
        public async Task<IActionResult> GetAllOrigins(string origin)
        {
            try
            {
                var listOrigins = await _flightService.GetAllOrigins(origin);
                return Ok(listOrigins);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Obtener todos los vuelos con el mismo destino
        [Route("destination/{destination}")]
        [HttpGet]
        public async Task<IActionResult> GetAllDestinations(string destination)
        {
            try
            {
                var listDestinations = await _flightService.GetAllDestinations(destination);
                return Ok(listDestinations);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Obtener todos los vuelos con el mismo destino y origen
        [Route("query/{origin}/{destination}")]
        [HttpGet]
        public async Task<IActionResult> GetFlights(string origin, string destination)
        {
            try
            {
                var listFlights = await _flightService.GetFlights(origin, destination);
                return Ok(listFlights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Actualizar vuelos
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] Flight flight)
        {
            try
            {
                if (id != flight.Id)
                {
                    return BadRequest();
                }

                await _flightService.UpdateFlight(flight);
                return Ok(new { message = "El vuelo fue actualizado con exito!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Eliminar vuelos
        [HttpDelete("{idFlight}")]
        public async Task<IActionResult> Delete(int idFlight)
        {
            try
            {
                var flight = await _flightService.SearchFlight(idFlight);
                if (flight == null)
                {
                    return BadRequest(new { message = "No se encontro ningun vuelo" });
                }
                await _flightService.DeleteFlight(flight);
                return Ok(new { message = "El vuelo fue eliminado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
