using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Queries.GetMaterials
{
    public class MaterialsVm
    {
        public IList<MaterialDto>? Materials { get; set; }
    }
}
