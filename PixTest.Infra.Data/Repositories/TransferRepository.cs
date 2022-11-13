using Microsoft.EntityFrameworkCore;
using PixTest.Domain.Entities;
using PixTest.Domain.Interfaces;
using PixTest.Infra.Data.Context;
using System.Threading.Tasks;

namespace PixTest.Infra.Data.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        ApplicationDbContext _applicationDbContext;

        public TransferRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task PostTransaction(Transfer transfer)
        {
            _applicationDbContext.Add(transfer);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<bool> ValidatePixKey(string pixKey)
        {
            return await _applicationDbContext.User.AnyAsync(u => u.PixKey == pixKey);          
        }
    }
}
