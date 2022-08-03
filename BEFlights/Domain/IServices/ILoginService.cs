using BEFlights.Domain.Models;
using System.Threading.Tasks;

namespace BEFlights.Domain.IServices
{
    public interface ILoginService
    {
        Task<Usuario> ValidateUser(Usuario usuario);
    }
}
