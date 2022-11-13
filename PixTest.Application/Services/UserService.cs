using PixTest.Application.DTOs;
using PixTest.Application.Helpers;
using PixTest.Application.Interfaces;
using PixTest.Domain.Entities;
using PixTest.Domain.Interfaces;
using System.Threading.Tasks;

namespace PixTest.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> PostUser(UserDTO userDTO)
        {
            if (await _userRepository.CheckPixKey(userDTO.PixKey) == true)
            {
                throw new AppException("Chave Pix foi usada, escolha outra chave para cadastrar");
            }

            var userEntity = new User(userDTO.Name, userDTO.Document, userDTO.PixKey);

            var entity = await _userRepository.PostUser(userEntity);

            return entity.Id.ToString();
        }

        public async Task<UserDTO> UserDetails(int id)
        {
            var userEntity = await _userRepository.UserDetails(id);

            if(userEntity == null)
            {
                throw new AppException("Usuario não encontrado");
            }

            UserDTO model = new UserDTO
            {
                Id = userEntity.Id,

                Name = userEntity.Name,

                Document = userEntity.Document,

                PixKey = userEntity.PixKey
            };

            return model;
        }
    }
}
