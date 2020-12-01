using ETC.EQM.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
 
    public class AddMaterialCommand : MaterialCommand
    {
        public AddMaterialCommand(string name)
        {
            Name = name;          
        }

        public override bool IsValid()
        {
            return true;
        }


    }
}
