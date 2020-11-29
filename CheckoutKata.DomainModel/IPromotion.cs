namespace CheckoutKata.DomainModel
{
    public interface IPromotion
    {
        string Description {get;}
        decimal CalculateDiscountToApply(IStockItem stockItem, int quantity);
    }
}