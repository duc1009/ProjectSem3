using ETC.EQM.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
 
    public abstract class MaterialCommand : Command
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Tên
        /// </summary>
        public string Name { get; set; }

       
    }
}
