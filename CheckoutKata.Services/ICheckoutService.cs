using System.Collections.Generic;
using CheckoutKata.DomainModel;

namespace CheckoutKata.Services
{
    public interface ICheckoutService
    {
        void AddItemToBasket(string stockItemSku);
        IEnumerable<IStockItem> GetAvailableStockItems();
        IBasket GetCurrentBasket();
    }
}