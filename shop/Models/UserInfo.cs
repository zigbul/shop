using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserInfo
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "Заполните логин")]
        public required string Login {  get; set; }

        [Required(ErrorMessage = "Заполните email")]
        public required string Email { get; set; }

        public string? Phone { get; set; }
    }
}
