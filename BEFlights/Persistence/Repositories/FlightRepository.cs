using BEFlights.Domain.IRepositories;
using BEFlights.Domain.Models;
using BEFlights.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BEFlights.Persistence.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;
        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveFlight(Flight flight)
        {
            _context.Add(flight);
            await _context.SaveChangesAsync();
        }

        public async Task<bool>ValidateExistence(Flight flight)
        {
            var validateExistence = await _context.Flight.AnyAsync(x => x.FlightNumber == flight.FlightNumber);
            return validateExistence;
        }

        public async Task<List<Flight>> GetAllFlights()
        {
            var listFlights = await _context.Flight.ToListAsync();

            return listFlights;
        }

        public async Task<List<Flight>> GetAllOrigins(string origin)
        {
            var listOrigins = await _context.Flight.Where(x => x.Origin == origin).ToListAsync();

            return listOrigins;
        }

        public async Task<List<Flight>> GetAllDestinations(string destination)
        {
            var listDestinations = await _context.Flight.Where(x => x.Destination == destination).ToListAsync();

            return listDestinations;
        }

        public async Task<Flight> GetFlights(string origin, string destination)
        {
            var listFlight = await _context.Flight.Where(x => x.Origin == origin && x.Destination == destination).FirstOrDefaultAsync();

            return listFlight;
        }

        public async Task UpdateFlight(Flight flight)
        {
            _context.Update(flight);
            await _context.SaveChangesAsync();
        }

        public async Task<Flight> SearchFlight(int idFlight)
        {
            var flight = await _context.Flight.Where(x => x.Id == idFlight).FirstOrDefaultAsync();

            return flight;
        }

        public async Task DeleteFlight(Flight flight)
        {
            _context.Flight.Remove(flight);
            await _context.SaveChangesAsync();
        }
    }
}
