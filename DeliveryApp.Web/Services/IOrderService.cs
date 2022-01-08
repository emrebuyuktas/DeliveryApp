using DeliveryApp.Core.Dtos;
using DeliveryApp.Web.Areas.Admin.Models;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IOrderService
    {
        Task<Order> GetOrdersAsync(string url);
        Task UpdateOrderAsync(OrderUpdateDto orderUpdateDto,string url);
    }
}
