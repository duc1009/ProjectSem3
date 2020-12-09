using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.ModelQueries
{
    public class BillDetailQueryModel
    {
        public Guid Id { get; set; }
        public string BillId { get; set; }
        public string Image { get; set; }
        public string SizeId { get; set; }
        public string MaterialId { get; set; }
    }
    public class BillDetailDTO
    {
        public Guid Id { get; set; }
        public string BillId { get; set; }
        public string Image { get; set; }
        public Guid SizeId { get; set; }
        public Guid MaterialId { get; set; }
    }
}
