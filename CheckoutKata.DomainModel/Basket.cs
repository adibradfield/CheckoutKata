using System.Collections.Generic;

namespace CheckoutKata.DomainModel
{
    class Basket : IBasket
    {
        private Dictionary<string, BasketLineItem> _lineItems = new Dictionary<string, BasketLineItem>();
        public IEnumerable<IBasketLineItem> LineItems => _lineItems.Values;

        public decimal TotalPrice => throw new System.NotImplementedException();

        public void AddItem(IStockItem item)
        {
            if(_lineItems.ContainsKey(item.SKU)){
                _lineItems[item.SKU].Quantity++;
            }
            else{
                _lineItems[item.SKU] = new BasketLineItem(item);
            }
        }
    }
}