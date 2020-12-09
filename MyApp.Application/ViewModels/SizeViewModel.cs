using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Application.ViewModels
{
   public class SizeViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
