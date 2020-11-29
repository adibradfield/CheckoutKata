namespace CheckoutKata.DomainModel
{
    class BasketLineItem : IBasketLineItem
    {
        public IStockItem StockItem { get; }

        public int Quantity { get; set; } = 1;

        public decimal LinePrice
        {
            get
            {
                var basePrice = StockItem.UnitPrice * Quantity;
                if(StockItem.Promotion != null){
                    return basePrice - StockItem.Promotion.CalculateDiscountToApply(Quantity);
                }
                return basePrice;
            }
        }

        public BasketLineItem(IStockItem item){
            StockItem = item;
        }
    }
}