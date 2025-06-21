using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Введите название роли")]
        public required string Name { get; set; }
    }
}
