namespace CheckoutKata.DomainModel.Promotions
{
    class PercentageDiscountPromotion : IPromotion
    {
        private readonly int qualifyingQuantity;
        private readonly decimal percentageDiscount;

        public string Description => throw new System.NotImplementedException();

        public PercentageDiscountPromotion(int qualifyingQuantity, decimal percentageDiscount)
        {
            this.qualifyingQuantity = qualifyingQuantity;
            this.percentageDiscount = percentageDiscount;
        }

        public decimal CalculateDiscountToApply(IStockItem stockItem, int quantity)
        {
            throw new System.NotImplementedException();
        }
    }
}