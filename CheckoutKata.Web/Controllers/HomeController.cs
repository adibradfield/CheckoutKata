using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CheckoutKata.Web.Models;
using CheckoutKata.Services;

namespace CheckoutKata.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICheckoutService _checkoutService;

        public HomeController(ILogger<HomeController> logger, ICheckoutService checkoutService)
        {
            _logger = logger;
            this._checkoutService = checkoutService;
        }

        public IActionResult Index()
        {
            return View(new CheckoutViewModel{
                AvailableStockItems = _checkoutService.GetAvailableStockItems(),
                Basket = _checkoutService.GetCurrentBasket()
            });
        }

        [HttpPost]
        public IActionResult AddItemToBasket(AddItemToBasketModel model){
            _checkoutService.AddItemToBasket(model.SKU);
            return RedirectToAction("Index");
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
}