using BEFlights.Domain.IRepositories;
using BEFlights.Domain.IServices;
using BEFlights.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEFlights.Services
{
    public class FlightService: IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task SaveFlight(Flight flight)
        {
            await _flightRepository.SaveFlight(flight);
        }

        public async Task<bool> ValidateExistence(Flight flight)
        {
            return await _flightRepository.ValidateExistence(flight);
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            return await _flightRepository.GetAllFlights();
        }

        public async Task<List<Flight>> GetAllOrigins(string origin)
        {
            return await _flightRepository.GetAllOrigins(origin);
        }

        public async Task<List<Flight>> GetAllDestinations(string destination)
        {
            return await _flightRepository.GetAllDestinations(destination);
        }

        public async Task<Flight> GetFlights(string origin, string destination)
        {
            return await _flightRepository.GetFlights(origin, destination);
        }
        public async Task UpdateFlight(Flight flight)
        {
            await _flightRepository.UpdateFlight(flight);
        }

        public async Task<Flight> SearchFlight(int idFlight)
        {
            return await _flightRepository.SearchFlight(idFlight);
        }

        public async Task DeleteFlight(Flight flight)
        {
            await _flightRepository.DeleteFlight(flight);
        }
    }
}
