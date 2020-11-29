namespace CheckoutKata.DomainModel.Promotions
{
    class FixedPricePromotion : IPromotion
    {
        private readonly int _qualifyingQuantity;
        private readonly decimal _price;

        public string Description => $"{_qualifyingQuantity} for {_price}";

        public FixedPricePromotion(int qualifyingQuantity, decimal price)
        {
            this._qualifyingQuantity = qualifyingQuantity;
            this._price = price;
        }

        public decimal CalculateDiscountToApply(IStockItem stockItem, int quantity)
        {
            var fullPriceForQualifyingQuantity = stockItem.UnitPrice * _qualifyingQuantity;
            var discountForQualifyingQuantity = fullPriceForQualifyingQuantity - _price;
            var numberOfTimesToApplyDiscount = quantity / _qualifyingQuantity;
            return discountForQualifyingQuantity * numberOfTimesToApplyDiscount;
        }
    }
}