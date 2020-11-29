namespace CheckoutKata.DomainModel
{
    class BasketLineItem : IBasketLineItem
    {
        public IStockItem StockItem { get; }

        public int Quantity { get; set; } = 1;

        public decimal LinePrice => throw new System.NotImplementedException();

        public BasketLineItem(IStockItem item){
            StockItem = item;
        }
    }
}