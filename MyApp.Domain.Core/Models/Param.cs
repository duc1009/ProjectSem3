using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Core.Models
{
    public class Param
    {
        private const int maxPageSize = int.MaxValue;
        private int _pageSize = int.MaxValue;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value < maxPageSize ? value : maxPageSize;
            }
        }

        private int _pageNumber;

        public int PageNumber
        {
            get
            {
                if (_pageNumber == 0) _pageNumber = 1;
                return _pageNumber;
            }
            set { _pageNumber = value; }
        }

        public string ManagementId { get; set; }
        public string ParentManagementId { get; set; }
        public string SchoolYearId { get; set; }
        public string UnitId { get; set; }
        public bool IsSchool { get; set; }
    }
}
