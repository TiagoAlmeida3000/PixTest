using Microsoft.EntityFrameworkCore;
using PixTest.Domain.Entities;
using PixTest.Domain.Interfaces;
using PixTest.Infra.Data.Context;
using System.Linq;
using System.Threading.Tasks;

namespace PixTest.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<User> PostUser(User user)
        {
           var entity =  _applicationDbContext.Add(user);

            await _applicationDbContext.SaveChangesAsync();

            return entity.Entity;
        }

        public async Task<User> UserDetails(int id)
        {
            return await _applicationDbContext.User.FindAsync(id);
        }

        public async Task<int> GetUserId(string pixKey)
        {
            int userId = await  _applicationDbContext.User.Where(u => u.PixKey == pixKey).Select(u => u.Id).FirstOrDefaultAsync();

            return userId;
        }

        public async Task<bool> CheckPixKey(string pixKey)
        {
            return await _applicationDbContext.User.AnyAsync(u => u.PixKey == pixKey);
        }
    }
}
