using ETC.EQM.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
 
    public  class DeleteMaterialCommand : MaterialCommand
    {
        public Guid[] Ids { get; set; }
        public DeleteMaterialCommand(Guid[] ids)
        {
            Ids = ids;
        }
        public override bool IsValid()
        {
            return true;
        }

    }
}
