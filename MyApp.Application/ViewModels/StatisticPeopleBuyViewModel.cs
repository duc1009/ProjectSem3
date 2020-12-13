using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class StatisticPeopleBuyViewModel
    {
        public StatisticPeopleBuyViewModel()
        {
            
        }
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double TotalMoney { get; set; }
    }
}
