using BEFlights.Domain.IRepositories;
using BEFlights.Domain.Models;
using BEFlights.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BEFlights.Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        public LoginRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            var user = await _context.Usuario.Where(x => x.NombreUsuario == usuario.NombreUsuario
                                                && x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}
