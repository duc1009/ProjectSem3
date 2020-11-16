using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MyApp.Application.ViewModels
{
    public class TodoAppViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        [DisplayName("Content")]
        public string Content { get; set; }

        [DisplayName("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("FinishedAt")]
        public DateTime FinishedAt { get; set; }

        public bool Reported { get; set; }
        public string Status { get; set; }

        public string Description { get; set; }
    }
}
