using MyApp.Domain.ModelQueries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Queries
{
    public interface IMaterialQueries
    {
        Task<List<MaterialDTO>> GetMaterial(MaterialQueryModel urlQuery);
    }
}
