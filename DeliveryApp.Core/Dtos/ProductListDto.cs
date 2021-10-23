using DeliveryApp.Core.Entities.Concrete;
using System.Collections.Generic;

namespace DeliveryApp.Core.Dtos
{
    public class ProductListDto
    {
        public IList<Product> Products { get; set; }
        public int? BrandId { get; set; }

    }
}
