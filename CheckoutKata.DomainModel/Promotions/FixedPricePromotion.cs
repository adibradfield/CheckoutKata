namespace CheckoutKata.DomainModel.Promotions
{
    class FixedPricePromotion : IPromotion
    {
        private readonly int _qualifyingQuantity;
        private readonly decimal _price;

        public string Description => throw new System.NotImplementedException();

        public FixedPricePromotion(int qualifyingQuantity, decimal price)
        {
            this._qualifyingQuantity = qualifyingQuantity;
            this._price = price;
        }

        public decimal CalculateDiscountToApply(IStockItem stockItem, int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}