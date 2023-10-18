using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirzhaMaterialov.Domain
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; } = null!;
    }
}
