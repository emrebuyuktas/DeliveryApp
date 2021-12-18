using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Web.Services
{
    public interface IServicesBase<Tin,Tout> where Tin: class where Tout: class
    {

        Task<Tout> GetAsync(string url);
    }
}
