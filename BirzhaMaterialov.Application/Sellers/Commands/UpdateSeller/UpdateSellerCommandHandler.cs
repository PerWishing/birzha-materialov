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

namespace BirzhaMaterialov.Application.Sellers.Commands.UpdateSeller
{
    public class UpdateSellerCommandHandler : IRequestHandler<UpdateSellerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateSellerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateSellerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == request.Id,
                cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Seller), request.Id);
            }

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
