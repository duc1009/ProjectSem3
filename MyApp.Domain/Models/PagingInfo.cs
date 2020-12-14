using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get
            {
                if (TotalItems == 0)
                {
                    return 0;
                }
                return (TotalItems / ItemsPerPage)
                    + (TotalItems % ItemsPerPage > 0 ? 1 : 0);
            }
        }
    }
}
