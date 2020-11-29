namespace CheckoutKata.DomainModel.Promotions
{
    class PercentageDiscountPromotion : IPromotion
    {
        private readonly int _qualifyingQuantity;
        private readonly decimal _percentageDiscount;

        public string Description => $"{_percentageDiscount}% off for every {_qualifyingQuantity} purchased together";

        public PercentageDiscountPromotion(int qualifyingQuantity, decimal percentageDiscount)
        {
            this._qualifyingQuantity = qualifyingQuantity;
            this._percentageDiscount = percentageDiscount;
        }

        public decimal CalculateDiscountToApply(IStockItem stockItem, int quantity)
        {
            var fullPriceForQualifyingQuantity = stockItem.UnitPrice * _qualifyingQuantity;
            var discountForQualifyingQuantity = fullPriceForQualifyingQuantity * (_percentageDiscount / 100);
            var numberOfTimesToApplyDiscount = quantity / _qualifyingQuantity;
            return discountForQualifyingQuantity * numberOfTimesToApplyDiscount;
        }
    }
}