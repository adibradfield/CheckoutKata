using System.Collections.Generic;

namespace CheckoutKata.DomainModel
{
    public interface IBasket
    {
        IEnumerable<IBasketLineItem> LineItems {get;}
        decimal TotalPrice {get;}
        void AddItem(IStockItem item);
    }
}