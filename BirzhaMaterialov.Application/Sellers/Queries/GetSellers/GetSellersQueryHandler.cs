using BirzhaMaterialov.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Queries.GetSellers
{
    public class GetSellersQueryHandler : IRequestHandler<GetSellersQuery, SellersVm>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetSellersQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SellersVm> Handle(GetSellersQuery request,CancellationToken cancellationToken)
        {
            var entityList = await _dbContext.Sellers.ToListAsync(cancellationToken);

            var sellersVm = new SellersVm();
            sellersVm.Sellers = new List<SellerDto>();

            foreach (var seller in entityList)
            {
                var sellerDto = new SellerDto 
                {
                    Id = seller.Id,
                    Name = seller.Name
                };

                sellersVm.Sellers.Add(sellerDto);
            }

            return sellersVm;
        }
    }
}
