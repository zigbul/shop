using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Pass
    {
        [Required]
        public required Guid Id { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string? OldPassword { get; set; }

        [Required(ErrorMessage = "Введите новый пароль")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Минимальная длина пароля от 5 до 10 символов")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Подтвердите новый пароль")]
        [Compare(nameof(NewPassword), ErrorMessage = "Пароли не совпадают")]
        public string? ConfirmNewPassword { get; set; }
    }
}
