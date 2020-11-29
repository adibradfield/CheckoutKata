using CheckoutKata.DomainModel;

namespace CheckoutKata.Services
{
    public interface IBasketRepository
    {
        IBasket GetCurrentBasket();
        void Persist(IBasket basket);
    }
}