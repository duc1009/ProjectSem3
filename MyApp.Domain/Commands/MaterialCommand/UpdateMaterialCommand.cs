using ETC.EQM.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
 
    public class UpdateMaterialCommand : MaterialCommand
    {
        public UpdateMaterialCommand(Guid id,string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}
