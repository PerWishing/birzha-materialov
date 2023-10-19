using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Queries.GetMaterial
{
    public class GetMaterialQuery : IRequest<MaterialVm>
    {
        public int Id { get; set; }
    }
}
