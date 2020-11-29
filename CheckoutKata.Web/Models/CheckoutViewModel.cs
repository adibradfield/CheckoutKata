using System.Collections.Generic;
using CheckoutKata.DomainModel;

namespace CheckoutKata.Web.Models
{
    public class CheckoutViewModel{
        public IBasket Basket { get; set; }
        public IEnumerable<IStockItem> AvailableStockItems { get; set; }
    }
}