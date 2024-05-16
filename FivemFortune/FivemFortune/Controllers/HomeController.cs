using FivemFortune.Data;
using FivemFortune.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FivemFortune.Logic;
using FivemFortune.Logic.Exceptions;

namespace FivemFortune.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Username _userService;

        private readonly Coins _coinService;
        private readonly CratesService _cratesService;


        public HomeController(ILogger<HomeController> logger, Username userService, Coins coinService, CratesService cratesService)
        {
            _logger = logger;
            _userService = userService;
            _coinService = coinService;
            _cratesService = cratesService;
        }

        public IActionResult Index()
        {

            string userName = _userService.GetUserName();
            ViewData["UserName"] = userName;

            int coins = _coinService.GetCoins();
            ViewData["Coins"] = coins;


            return View();
        }

        public IActionResult Cratepage()
        {
            string userName = _userService.GetUserName();
            ViewData["UserName"] = userName;

            int coins = _coinService.GetCoins();
            ViewData["Coins"] = coins;

            List<Crates> crates = _cratesService.GetAllCrates();
            ViewBag.Crates = crates;

            return View();
        }

        [HttpGet]
        public IActionResult BuyCrate(int price)
        {
            int coins = _coinService.GetCoins();
            try
            {
                var (success, message, colorClass) = _coinService.BuyCrate(price);
                return Json(new { success = success, coins = coins, message = message, colorClass = colorClass });
            }
            catch (NegativeCoinsToRemoveException e)
            {
                string errorMessage = $"Fout, probeerde negatieve coins ervanaf te halen: {e.CoinsAmount}";
                return Json(new { success = true, coins = coins, message = errorMessage, colorClass = "text-danger" });
            }
            catch (ToHighCoinsToRemoveException e)
            {
                string errorMessage = $"Fout, probeerde te veel coins eraf te halen: {e.CoinsAmount}";
                return Json(new { success = true, coins = coins, message = errorMessage, colorClass = "text-danger" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
