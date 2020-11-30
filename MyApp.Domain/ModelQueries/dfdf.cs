using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.ModelQueries
{
    public class MaterialQueryModel 
    {
        /// <summary>
        /// Tên
        /// </summary>
        public string Name { get; set; }

    }
    public class MaterialDTO 
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Tên
        /// </summary>
        public string Name { get; set; }
              
    }
}
