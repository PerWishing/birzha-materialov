using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Application.Sellers.Queries.GetSeller
{
    public class GetSellerQuery : IRequest<SellerVm>
    {
        public int Id { get; set; }
    }
}
