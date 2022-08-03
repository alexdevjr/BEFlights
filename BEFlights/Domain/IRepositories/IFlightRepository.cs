using BEFlights.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEFlights.Domain.IRepositories
{
    public interface IFlightRepository
    {
        Task SaveFlight(Flight flight);
        Task<bool> ValidateExistence(Flight flight);
        Task<List<Flight>> GetAllFlights();
        Task<List<Flight>> GetAllOrigins(string origin);
        Task<List<Flight>> GetAllDestinations(string destination);
        Task<Flight> GetFlights(string origin, string destination);
        Task UpdateFlight(Flight flight);
        Task<Flight> SearchFlight(int idFlight);
        Task DeleteFlight(Flight flight);
    }
}
