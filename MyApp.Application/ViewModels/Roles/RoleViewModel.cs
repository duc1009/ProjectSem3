
using System.ComponentModel.DataAnnotations;

namespace MyApp.Application.ViewModels.Roles
{
    public class RoleViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập tên Role")]
        public string Role { get; set; }
    }
}
