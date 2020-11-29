namespace CheckoutKata.DomainModel
{
    public interface IBasketLineItem
    {
        IStockItem StockItem {get;}
        int Quantity {get;}
        decimal LinePrice {get;}
    }
}