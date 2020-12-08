using System;

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
