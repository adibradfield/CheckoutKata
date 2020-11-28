using System.Collections.Generic;

namespace CheckoutKata.Web.Models
{
    public class CheckoutViewModel{
        public IBasket Basket { get; set; }
        public IEnumerable<IStockItem> AvailableStockItems { get; set; }
    }

    public interface IStockItem
    {
        string SKU {get;}
        decimal UnitPrice {get;}
        IOffer Offer {get;}
    }

    public interface IOffer
    {
        string Description {get;}
    }

    public interface IBasket
    {
        IEnumerable<IBasketLineItem> LineItems {get;}
        decimal TotalPrice {get;}
    }

    public interface IBasketLineItem
    {
        IStockItem StockItem {get;}
        int Quantity {get;}
        decimal LinePrice {get;}
    }
}