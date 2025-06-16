using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Auth
    {
        [Required(ErrorMessage = "Введите логин")]
        public required string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public required string Password { get; set; }

        public bool IsRemembered { get; set; }
    }
}