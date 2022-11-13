using PixTest.Domain.Entities;
using System.Threading.Tasks;

namespace PixTest.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> PostUser(User user);

        Task<User> UserDetails(int id);

        Task<int> GetUserId(string pixKey);

        Task<bool> CheckPixKey(string pixKey);
    }
}
