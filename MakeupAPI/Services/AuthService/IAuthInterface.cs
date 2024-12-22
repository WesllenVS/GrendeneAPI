using MakeupAPI.Dto;
using MakeupAPI.Models;

namespace MakeupAPI.Services.User
{
    public interface IAuthInterface
    {
        Task<ResponseModel<UserCreateDto>> Registrar(UserCreateDto userRegistro);
        Task<ResponseModel<string>> Login(UserLoginDto userLogin);

    }
}
