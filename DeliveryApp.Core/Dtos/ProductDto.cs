

using System.Collections.Generic;

namespace DeliveryApp.Core.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductBrand { get; set; }
        public string ProductType { get; set; }        
        public string PictureUrl { get; set; }
        public IList<CommentDto> Comments { get; set; }
        public virtual int Quantity { get; set; } = 0;
    }
}
