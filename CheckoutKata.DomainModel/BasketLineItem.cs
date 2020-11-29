namespace CheckoutKata.DomainModel
{
    class BasketLineItem : IBasketLineItem
    {
        public IStockItem StockItem { get; }

        public int Quantity { get; set; } = 1;

        public decimal LinePrice => StockItem.UnitPrice * Quantity;

        public BasketLineItem(IStockItem item){
            StockItem = item;
        }
    }
}