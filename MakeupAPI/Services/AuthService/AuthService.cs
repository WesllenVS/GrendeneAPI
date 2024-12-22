using MakeupAPI.Data;
using MakeupAPI.Dto;
using MakeupAPI.Models;
using MakeupAPI.Services.SenhaService;
using Microsoft.EntityFrameworkCore;

namespace MakeupAPI.Services.User
{
    public class AuthService : IAuthInterface
    {

        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;

        public AuthService(AppDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<UserCreateDto>> Registrar(UserCreateDto userRegistro)
        {
            ResponseModel<UserCreateDto> resposta = new ResponseModel<UserCreateDto>();

            try
            {
                if (!VerificaUser(userRegistro))
                {
                    resposta.Dados = null;
                    resposta.Status = false;
                    resposta.Mensagem = "Usuário já cadastrado";

                    return resposta;
                }

                _senhaInterface.CriarSenhaHash(userRegistro.Senha, out byte[] senhaHash, out byte[] senhaSalt );

                UserModel usuario = new UserModel()
                {
                    Usuario = userRegistro.Usuario,
                    Cargo = userRegistro.Cargo,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt,
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                resposta.Mensagem = "Usuário cadastrado com sucesso";

            }
            catch (Exception ex)
            {
                resposta.Dados = null;  
                resposta.Mensagem = ex.Message;
                resposta.Status = false;

            }

            return resposta;
        }


        public async Task<ResponseModel<string>> Login(UserLoginDto userLogin) 
        {
            ResponseModel<string> resposta = new ResponseModel<string>();

            try
            {
                var usuario = await _context.Users.FirstOrDefaultAsync(userBanco => userBanco.Usuario == userLogin.Usuario);

                if (usuario == null)
                {
                    resposta.Mensagem = "Credenciais inválidas";
                    resposta.Status = false;
                    return resposta;
                }

                if (!_senhaInterface.VerificaSenhaHash(userLogin.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    resposta.Mensagem = "Credenciais inválidas";
                    resposta.Status = false;
                    return resposta;
                }

                var token = _senhaInterface.CriarToken(usuario);

                resposta.Dados = token;
                resposta.Mensagem = "Usuário logado com sucesso";

            }
            catch (Exception ex)
            {
                resposta.Dados = null;
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
            }

            return resposta;
        }

        public bool VerificaUser(UserCreateDto userRegistro)
        { 
            var user = _context.Users.FirstOrDefault(userBanco => userBanco.Usuario == userRegistro.Usuario);

            if (user != null) return false;

            return true;
        }

    }
}
