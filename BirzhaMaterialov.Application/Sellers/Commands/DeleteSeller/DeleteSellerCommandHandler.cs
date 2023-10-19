using BirzhaMaterialov.Application.Common.Exceptions;
using BirzhaMaterialov.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommandHandler : IRequestHandler<DeleteSellerCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteSellerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteSellerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == request.Id,
                cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            _dbContext.Sellers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
