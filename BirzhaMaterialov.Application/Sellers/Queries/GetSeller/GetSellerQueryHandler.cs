using BirzhaMaterialov.Application.Common.Exceptions;
using BirzhaMaterialov.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Queries.GetSeller
{
    public class GetSellerQueryHandler : IRequestHandler<GetSellerQuery, SellerVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetSellerQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SellerVm> Handle(GetSellerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == request.Id,
                cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(entity), request.Id);
            }

            var sellerVm = new SellerVm
            {
                Id = entity.Id,
                Name = entity.Name
            };

            return sellerVm;
        }
    }
}
