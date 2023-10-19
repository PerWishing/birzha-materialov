using BirzhaMaterialov.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Queries.GetMaterials
{
    public class GetMaterialsQueryHandler : IRequestHandler<GetMaterialsQuery, MaterialsVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetMaterialsQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MaterialsVm> Handle(GetMaterialsQuery request, CancellationToken cancellationToken)
        {
            var entityList = await _dbContext.Materials.ToListAsync(cancellationToken);

            var materialsVm = new MaterialsVm();
            materialsVm.Materials = new List<MaterialDto>();

            foreach (var material in entityList)
            {
                var materialDto = new MaterialDto
                {
                    Id = material.Id,
                    Name = material.Name,
                    Price = material.Price
                };

                materialsVm.Materials.Add(materialDto);
            }

            return materialsVm;
        }
    }
}
