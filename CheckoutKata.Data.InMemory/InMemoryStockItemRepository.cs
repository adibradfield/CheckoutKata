using System.Collections.Generic;
using System.Linq;
using CheckoutKata.DomainModel;
using CheckoutKata.DomainModel.Promotions;
using CheckoutKata.Services;

namespace CheckoutKata.Data.InMemory
{
    public class InMemoryStockItemRepository : IStockItemRepository
    {
        private List<IStockItem> _availableStockItems = new List<IStockItem>{
            new StockItem{
                SKU = "A",
                UnitPrice = 10
            },
            new StockItem{
                SKU = "B",
                UnitPrice = 15,
                Promotion = new FixedPricePromotion(3, 40)
            },
            new StockItem{
                SKU = "C",
                UnitPrice = 40
            },
            new StockItem{
                SKU = "D",
                UnitPrice = 55,
                Promotion = new PercentageDiscountPromotion(2, 25)
            }
        };

        public IEnumerable<IStockItem> GetAvailableStockItems()
        {
            return _availableStockItems.AsReadOnly();
        }

        public IStockItem GetItem(string stockItemSku)
        {
            return _availableStockItems.SingleOrDefault(s => s.SKU == stockItemSku);
        }
    }
}