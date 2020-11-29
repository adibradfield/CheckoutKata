using System.Collections.Generic;
using CheckoutKata.DomainModel;

namespace CheckoutKata.Services
{
    public interface IStockItemRepository
    {
        IStockItem GetItem(string stockItemSku);
        IEnumerable<IStockItem> GetAvailableStockItems();
    }
}