using Moq;
using NUnit.Framework;

namespace CheckoutKata.DomainModel.UnitTests
{
    public class BasketLineItemTests{
        [TestCase(3.45, 1, ExpectedResult=3.45)]
        [TestCase(7.15, 1, ExpectedResult=7.15)]
        [TestCase(3.45, 2, ExpectedResult=6.90)]
        [TestCase(3.45, 3, ExpectedResult=10.35)]
        public decimal LinePrice_NoOffer_EqualsUnitPriceTimesQuantity(decimal unitPrice, int quantity){
            var stockItemMock = new Mock<IStockItem>();
            stockItemMock.Setup(m => m.UnitPrice).Returns(unitPrice);

            var lineItem = new BasketLineItem(stockItemMock.Object){Quantity = quantity};

            return lineItem.LinePrice;
        }

        [TestCase(3.45, 1, 0, ExpectedResult=3.45)]
        [TestCase(3.45, 1, 1, ExpectedResult=2.45)]
        [TestCase(3.45, 2, 4, ExpectedResult=2.90)]
        public decimal LinePrice_WithPromotion_PromotionDiscountApplied(decimal unitPrice, int quantity, decimal discountToApply){
            var promotionMock = new Mock<IPromotion>();
            promotionMock.Setup(m => m.CalculateDiscountToApply(It.IsAny<IStockItem>(), quantity)).Returns(discountToApply);
            var stockItemMock = new Mock<IStockItem>();
            stockItemMock.Setup(m => m.UnitPrice).Returns(unitPrice);
            stockItemMock.Setup(m => m.Promotion).Returns(promotionMock.Object);

            var lineItem = new BasketLineItem(stockItemMock.Object){Quantity = quantity};

            return lineItem.LinePrice;
        }
    }
}