using CheckoutKata.DomainModel;
using CheckoutKata.Services;

namespace CheckoutKata.Data.InMemory
{
    public class InMemoryBasketRepository : IBasketRepository
    {
        private IBasket currentBasket = new Basket();
        public IBasket GetCurrentBasket()
        {
            return currentBasket;
        }

        public void Persist(IBasket basket)
        {
            currentBasket = basket;
        }
    }
}
