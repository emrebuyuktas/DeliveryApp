using DeliveryApp.Core.Dtos;
using DeliveryApp.Core.Repositories.Abstract;
using DeliveryApp.Data.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryApp.Data.Repositories
{
    public class OrderProductRepository:RepositoryBase<OrderProduct>,IOrderProductRepository
    {
        public OrderProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
