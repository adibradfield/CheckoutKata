using CheckoutKata.DomainModel.Promotions;
using Moq;
using NUnit.Framework;

namespace CheckoutKata.DomainModel.UnitTests.Promotions
{
    public class PercentageDiscountPromotionTests
    {
        [Test]
        public void CalculateDiscountToApply_LessThanQualifyingQuantity_NoDiscount(){
            var mockStockItem = new Mock<IStockItem>();
            mockStockItem.Setup(m => m.UnitPrice).Returns(20m);
            var promotion = new PercentageDiscountPromotion(qualifyingQuantity: 3, percentageDiscount: 40);

            var result = promotion.CalculateDiscountToApply(mockStockItem.Object, 2);

            Assert.That(result, Is.EqualTo(0m));
        }

        [Test]
        public void CalculateDiscountToApply_EqualsQualifyingQuantity_DiscountedBy20(){
            var mockStockItem = new Mock<IStockItem>();
            mockStockItem.Setup(m => m.UnitPrice).Returns(20m);
            var promotion = new PercentageDiscountPromotion(qualifyingQuantity: 3, percentageDiscount: 40);

            var result = promotion.CalculateDiscountToApply(mockStockItem.Object, 3);

            Assert.That(result, Is.EqualTo(15m));
        }

        [Test]
        public void CalculateDiscountToApply_GreaterThanQualifyingQuantity_DiscountedBy20(){
            var mockStockItem = new Mock<IStockItem>();
            mockStockItem.Setup(m => m.UnitPrice).Returns(20m);
            var promotion = new PercentageDiscountPromotion(qualifyingQuantity: 3, percentageDiscount: 40);

            var result = promotion.CalculateDiscountToApply(mockStockItem.Object, 5);

            Assert.That(result, Is.EqualTo(15m));
        }

        [Test]
        public void CalculateDiscountToApply_DoubleQualifyingQuantity_DiscountedBy40(){
            var mockStockItem = new Mock<IStockItem>();
            mockStockItem.Setup(m => m.UnitPrice).Returns(20m);
            var promotion = new PercentageDiscountPromotion(qualifyingQuantity: 3, percentageDiscount: 40);

            var result = promotion.CalculateDiscountToApply(mockStockItem.Object, 6);

            Assert.That(result, Is.EqualTo(30m));
        }
    }
}