using PixTest.Application.DTOs;
using System.Threading.Tasks;

namespace PixTest.Application.Interfaces
{
    public interface IUserService
    {
        Task<string> PostUser(UserDTO user);

        Task<UserDTO> UserDetails(int id);
    }
}
