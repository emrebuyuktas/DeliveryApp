using DeliveryApp.Core.Entities.Abstaract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Core.Dtos
{
    public class OrderProduct:IEntity
    {
        public int OrdersId { get; set; }
        public int ProductsId { get; set; }
    }
}
