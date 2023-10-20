using BirzhaMaterialov.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Materials.Commands.UpdateMaterialsPrices
{
    public class UpdateMaterialsPricesCommandHandler : IRequestHandler<UpdateMaterialsPricesCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateMaterialsPricesCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateMaterialsPricesCommand request, CancellationToken cancellationToken)
        {
            var materials = await _dbContext.Materials.ToListAsync();

            if (materials == null || !materials.Any())
            {
                return;
            }

            var rnd = new Random();
            foreach (var material in materials)
            {
                material.Price = new decimal(rnd.Next(1, 101));
            }

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
