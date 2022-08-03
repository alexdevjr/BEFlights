using BEFlights.Domain.Models;
using System.Threading.Tasks;

namespace BEFlights.Domain.IRepositories
{
    public interface ILoginRepository
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
