namespace CheckoutKata.DomainModel
{
    public class StockItem : IStockItem
    {
        public string SKU {get;set;}

        public decimal UnitPrice {get;set;}

        public IPromotion Promotion {get;set;}
    }
}