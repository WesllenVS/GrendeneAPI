using MakeupAPI.Enum;

namespace MakeupAPI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; } 
        public CargoEnum Cargo { get; set; }
        public byte[] SenhaHash { get; set; }
        public byte[] SenhaSalt { get; set; }
        public DateTime TokenDtCriacao { get; set; } = DateTime.Now;
    }
}
