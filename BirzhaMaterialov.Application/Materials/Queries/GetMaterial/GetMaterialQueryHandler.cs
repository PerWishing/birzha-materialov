using BirzhaMaterialov.Application.Common.Exceptions;
using BirzhaMaterialov.Application.Interfaces;
using BirzhaMaterialov.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Queries.GetMaterial
{
    public class GetMaterialQueryHandler : IRequestHandler<GetMaterialQuery,MaterialVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetMaterialQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MaterialVm> Handle(GetMaterialQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Materials.FirstOrDefaultAsync(material => material.Id == request.Id,
                cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            var materialVm = new MaterialVm
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price
            };

            return materialVm;
        }
    }
}
