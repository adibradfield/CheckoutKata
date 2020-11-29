using System.Collections.Generic;

namespace CheckoutKata.DomainModel
{
    class Basket : IBasket
    {
        public IEnumerable<IBasketLineItem> LineItems => throw new System.NotImplementedException();

        public decimal TotalPrice => throw new System.NotImplementedException();

        public void AddItem(IStockItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}