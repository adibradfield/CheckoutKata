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
    }
}