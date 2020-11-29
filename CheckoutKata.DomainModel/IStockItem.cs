namespace CheckoutKata.DomainModel
{
    public interface IStockItem
    {
        string SKU {get;}
        decimal UnitPrice {get;}
        IOffer Offer {get;}
    }
}