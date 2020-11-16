using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MyApp.Application.ViewModels.Account
{
    public class LoginViewModel
    {

        [Required(ErrorMessage ="Vui lòng nhập Email")]
        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage ="Vui lòng nhập mật khẩu")]
        [DisplayName("PassWord")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [DisplayName("Remember")]
        public bool Remember { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

    }
}
