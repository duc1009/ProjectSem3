using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Application.ViewModels.Manager
{
    public class AddMemberViewModel
    {
        public string ManagerId { get; set; }

        public string Email { get; set; }

        public List<string> Members { get; set; }

        [Required]
        public string NewMember { get; set; }
    }
}
