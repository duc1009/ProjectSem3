using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Application.ViewModels.AuthorForUser
{
    public class UserRolesModel
    {
        [Key]
        public string Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public List<string> RolesName { get; set; }

        [Required]
        public string NewRole { get; set; }
    }
}
