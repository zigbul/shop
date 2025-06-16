using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        public required Guid Id { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Логин должен быть от 3ёх до 10 символов")]
        public required string Login { get; set; }

        [Required(ErrorMessage = "Укажите ваш email")]
        [EmailAddress(ErrorMessage = "Введите валидный email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Подтвердите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public required string ConfirmPassword { get; set; }
    }
}
