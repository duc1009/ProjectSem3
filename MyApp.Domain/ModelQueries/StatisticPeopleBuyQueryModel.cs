using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.ModelQueries
{
    public class StatisticPeopleBuyQueryModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string User { get; set; }
        public double TotalMoney { get; set; }
    }
    public class StatisticPeopleBuyDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string User { get; set; }
        public double TotalMoney { get; set; }
    }

}
