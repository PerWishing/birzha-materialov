using BirzhaMaterialov.Application.Common.Exceptions;
using BirzhaMaterialov.Application.Interfaces;
using BirzhaMaterialov.Application.Sellers.Commands.DeleteSeller;
using BirzhaMaterialov.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialCommandHandler : IRequestHandler<DeleteMaterialCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteMaterialCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteMaterialCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Materials.FirstOrDefaultAsync(material => material.Id == request.Id,
                cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Material), request.Id);
            }

            _dbContext.Materials.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
