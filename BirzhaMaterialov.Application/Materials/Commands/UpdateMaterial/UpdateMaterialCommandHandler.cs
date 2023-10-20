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

namespace BirzhaMaterialov.Application.Materials.Commands.UpdateMaterial
{
    public class UpdateMaterialCommandHandler : IRequestHandler<UpdateMaterialCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateMaterialCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Materials.FirstOrDefaultAsync(material => material.Id == request.Id,
                cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            entity.Name = request.Name;
            entity.Price = request.Price;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
