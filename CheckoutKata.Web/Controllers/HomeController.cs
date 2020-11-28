using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CheckoutKata.Web.Models;

namespace CheckoutKata.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new CheckoutViewModel{
                AvailableStockItems = new IStockItem[]{new MockStockItem()},
                Basket = new MockBasket()
            });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    class MockStockItem : IStockItem
    {
        public string SKU => "A";

        public decimal UnitPrice => 10;

        public IOffer Offer => null;
    }

    class MockBasket : IBasket
    {
        public IEnumerable<IBasketLineItem> LineItems => new IBasketLineItem[]{};

        public decimal TotalPrice => 0;
    }
}
