using BirzhaMaterialov.Application.Interfaces;
using BirzhaMaterialov.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Commands.CreateSeller
{
    public class CreateSellerCommandHandler : IRequestHandler<CreateSellerCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateSellerCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateSellerCommand request,
    CancellationToken cancellationToken)
        {
            var seller = new Seller
            {
                Name = request.Name,
            };

            await _dbContext.Sellers.AddAsync(seller);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return seller.Id;
        }
    }
}
