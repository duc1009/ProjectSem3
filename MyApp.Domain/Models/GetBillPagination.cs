using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class GetBillPagination
    {
        public IEnumerable<Bill> ListHoaDon { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
