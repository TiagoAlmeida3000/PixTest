using PixTest.Application.DTOs;
using System.Threading.Tasks;

namespace PixTest.Application.Interfaces
{
    public interface ITransferService
    {
        Task<string> PostTransaction(TransferDTO transfer);
    }
}
