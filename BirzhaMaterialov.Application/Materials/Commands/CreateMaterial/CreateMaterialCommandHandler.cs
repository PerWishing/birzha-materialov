using BirzhaMaterialov.Application.Common.Exceptions;
using BirzhaMaterialov.Application.Interfaces;
using BirzhaMaterialov.Application.Sellers.Commands.CreateSeller;
using BirzhaMaterialov.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommandHandler : IRequestHandler<CreateMaterialCommand, int>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateMaterialCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            var seller = await _dbContext.Sellers.FirstOrDefaultAsync(seller => seller.Id == request.SellerId,
                cancellationToken);

            if(seller == null)
            {
                throw new NotFoundException(nameof(seller), request.SellerId);
            }

            var material = new Material
            {
                Name = request.Name,
                Price = request.Price,
                Seller = seller
            };

            await _dbContext.Materials.AddAsync(material);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return material.Id;
        }
    }
}
