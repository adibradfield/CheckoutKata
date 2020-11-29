namespace CheckoutKata.DomainModel
{
    public interface IPromotion
    {
        string Description {get;}
        decimal CalculateDiscountToApply(int quantity);
    }
}