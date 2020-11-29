using System.Collections.Generic;
using CheckoutKata.DomainModel;

namespace CheckoutKata.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IStockItemRepository _stockItemRepository;

        public CheckoutService(IBasketRepository basketRepository, IStockItemRepository stockItemRepository)
        {
            this._basketRepository = basketRepository;
            this._stockItemRepository = stockItemRepository;
        }

        public void AddItemToBasket(string stockItemSku)
        {
            IBasket basket = _basketRepository.GetCurrentBasket();
            IStockItem item = _stockItemRepository.GetItem(stockItemSku);
            basket.AddItem(item);
            _basketRepository.Persist(basket);
        }

        public IBasket GetCurrentBasket()
        {
            return _basketRepository.GetCurrentBasket();
        }

        public IEnumerable<IStockItem> GetAvailableStockItems()
        {
            return _stockItemRepository.GetAvailableStockItems();
        }
    }
}