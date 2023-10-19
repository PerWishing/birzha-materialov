using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Commands.DeleteSeller
{
    public class DeleteSellerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
