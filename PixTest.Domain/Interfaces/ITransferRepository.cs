using PixTest.Domain.Entities;
using System.Threading.Tasks;

namespace PixTest.Domain.Interfaces
{
    public interface ITransferRepository
    {
        Task PostTransaction(Transfer transfer);

        Task<bool> ValidatePixKey(string pixKey);
    }
}
