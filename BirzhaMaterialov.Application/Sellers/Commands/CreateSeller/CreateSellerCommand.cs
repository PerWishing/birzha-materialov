using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Commands.CreateSeller
{
    public class CreateSellerCommand : IRequest<int>
    {
        public string Name { get; set; } = null!;
    }
}
