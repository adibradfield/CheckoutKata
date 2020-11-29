using NUnit.Framework;
using Moq;
using System.Linq;

namespace CheckoutKata.DomainModel.UnitTests
{
    public class Tests
    {
        private IStockItem _mockStockItemA;
        private IStockItem _mockStockItemB;

        [SetUp]
        public void Setup()
        {
            _mockStockItemA = GenerateMockStockItem("MockSkuA");
            _mockStockItemB = GenerateMockStockItem("MockSkuB");
        }

        private IStockItem GenerateMockStockItem(string mockSKU)
        {
            var mockItem = new Mock<IStockItem>();
            mockItem.Setup(m => m.SKU).Returns(mockSKU);
            return mockItem.Object;
        }

        [Test]
        public void AddItem_SingleItemOnce_SingleLineWithQuantity1()
        {
            var basket = new Basket();

            basket.AddItem(_mockStockItemA);

            Assert.That(basket.LineItems.Count(), Is.EqualTo(1));
            var lineItem = basket.LineItems.Single();
            Assert.That(lineItem.Quantity, Is.EqualTo(1));
            Assert.That(lineItem.StockItem.SKU, Is.EqualTo(_mockStockItemA.SKU));
        }

        [Test]
        public void AddItem_SingleItemTwice_SingleLineWithQuantity2(){
            var basket = new Basket();
            
            basket.AddItem(_mockStockItemA);
            basket.AddItem(_mockStockItemA);

            Assert.That(basket.LineItems.Count(), Is.EqualTo(1));
            var lineItem = basket.LineItems.Single();
            Assert.That(lineItem.Quantity, Is.EqualTo(2));
            Assert.That(lineItem.StockItem.SKU, Is.EqualTo(_mockStockItemA.SKU));
        }

        [Test]
        public void AddItem_TwoItemsOnce_TwoLinesWithQuantity1()
        {
            var basket = new Basket();

            basket.AddItem(_mockStockItemA);
            basket.AddItem(_mockStockItemB);

            Assert.That(basket.LineItems.Count(), Is.EqualTo(2));
            AssertLineQuantity(basket, _mockStockItemA, 1);
            AssertLineQuantity(basket, _mockStockItemB, 1);
        }

        [Test]
        public void AddItem_TwoItemsDifferentAmounts_TwoLinesWithCorrectQuantites(){
            var basket = new Basket();

            basket.AddItem(_mockStockItemA);
            basket.AddItem(_mockStockItemA);
            basket.AddItem(_mockStockItemB);

            Assert.That(basket.LineItems.Count(), Is.EqualTo(2));
            AssertLineQuantity(basket, _mockStockItemA, 2);
            AssertLineQuantity(basket, _mockStockItemB, 1);
        }

        private static void AssertLineQuantity(Basket basket, IStockItem stockItem, int quantity)
        {
            Assert.That(basket.LineItems.Where(l => l.StockItem.SKU == stockItem.SKU).Count(), Is.EqualTo(1));
            Assert.That(basket.LineItems.Single(l => l.StockItem.SKU == stockItem.SKU).Quantity, Is.EqualTo(quantity));
        }
    }
}