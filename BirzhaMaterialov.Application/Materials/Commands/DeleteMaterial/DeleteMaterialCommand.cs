using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommand : IRequest
    {
        public int Id { get; set; }
    }
}
