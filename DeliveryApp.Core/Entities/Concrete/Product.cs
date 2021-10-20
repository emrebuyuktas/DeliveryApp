using DeliveryApp.Core.Entities.Abstaract;

namespace DeliveryApp.Core.Entities.Concrete
{
    public class Product:EntityBase,IEntity
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set; }
    }
}
