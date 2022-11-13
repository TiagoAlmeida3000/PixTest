using PixTest.Application.DTOs;
using PixTest.Application.Helpers;
using PixTest.Application.Interfaces;
using PixTest.Domain.Entities;
using PixTest.Domain.Interfaces;
using System.Threading.Tasks;

namespace PixTest.Application.Services
{
    public class TransferService : ITransferService
    {
        private ITransferRepository _transferRepository;

        private IUserRepository _userRepository;

        public TransferService(ITransferRepository transferRepository, IUserRepository userRepository)
        {
            _transferRepository = transferRepository;

            _userRepository = userRepository;
        }

        public async Task<string> PostTransaction(TransferDTO transfer)
        {
            if (transfer.PixOriginKey == transfer.PixDestinationKey)
            {
                throw new AppException("Transferencia não realizada. Chave Pix de origem não pose ser igual a chave Pix de destino.");
            }

            if (await _transferRepository.ValidatePixKey(transfer.PixOriginKey) == false)
            {
                throw new AppException("Transferencia não realizada. Chave Pix de origem incorreta.");
            }

            if (await _transferRepository.ValidatePixKey(transfer.PixDestinationKey) == false)
            {
                throw new AppException("Transferencia não realizada. Chave Pix de destino incorreta.");
            }

            if (transfer.Value <= 0)
            {
                throw new AppException("Transferencia não realizada. Valor tem que ser maior que zero.");
            }

            transfer.UserId = await _userRepository.GetUserId(transfer.PixOriginKey);

            var tranferEntity = new Transfer(transfer.Value, transfer.PixOriginKey, transfer.PixDestinationKey, transfer.UserId);

            await _transferRepository.PostTransaction(tranferEntity);

            return "Transferencia realizada com sucesso";
        }
    }
}
