using DeliveryApp.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Shared.Dtos
{
    public class ProductListDto
    {
        public IList<Product> Products { get; set; }
        public int? BrandId { get; set; }

    }
}
