using System;
using System.Collections.Generic;

namespace ETC.EQM.Domain.Core.Pagination
{
    public class UrlQuery
    {
        private const int maxPageSize = int.MaxValue;
        private int pageNumber = 1;
        public int? PageNumber
        {
            get
            {
                return pageNumber;
            }
            set
            {
                pageNumber = value ?? 1;
            }
        }
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
        public string Keyword { get; set; }

        public string ManagementId { get; set; }
        public string SchoolYearId { get; set; }
        public string UnitId { get; set; }
        public int PortalId { get; set; }
        public string RoleIdentity { get; set; }
    }

    public class UrlQuerySeftAssessment
    {
        private const int maxPageSize = 100;
        private int pageNumber = 1;
        public int? PageNumber
        {
            get
            {
                return pageNumber;
            }
            set
            {
                pageNumber = value ?? 1;
            }
        }
        private int _pageSize = 50;
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
        public string Keyword { get; set; }

        public string SelfAssessmentManagementId { get; set; }

        public string SchoolYearId { get; set; }
        public int PortalId { get; set; }
    }

    public sealed class Pagination<T>
    {
        public int TotalRecord { get; set; }
        public List<T> PageLists { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
    }

    public class PageData
    {
        public List<int> PageSizes { get; set; } = new List<int>() { 10, 20, 50, 100 };
    }
}
