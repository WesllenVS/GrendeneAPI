using System.ComponentModel.DataAnnotations;

namespace MakeupAPI.Dto
{
    public class UserLoginDto
    {
        [Required(ErrorMessage = "O campo usuário é obrigatório")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "O campo senha é obrigatório")]
        public string Senha { get; set; }
    }
}
