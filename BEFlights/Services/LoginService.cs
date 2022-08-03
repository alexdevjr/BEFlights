using BEFlights.Domain.IRepositories;
using BEFlights.Domain.IServices;
using BEFlights.Domain.Models;
using System.Threading.Tasks;

namespace BEFlights.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            return await _loginRepository.ValidateUser(usuario);
        }
    }
}
