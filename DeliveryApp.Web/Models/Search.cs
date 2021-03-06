using DeliveryApp.Core.Dtos;
using DeliveryApp.Shared.Result.ComplexTypes;
using System;

namespace DeliveryApp.Web.Models
{
    public class Search
    {
        public ProductListDto Data { get; set; }

        public ResultStatus ResultStatus { get; set; }

        public string Message { get; set; }

        public Exception Exception { get; set; }
    }
}
