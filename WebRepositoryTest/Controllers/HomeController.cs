using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using WebRepositoryTest.Database;
using WebRepositoryTest.Models;

namespace WebRepositoryTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceProvider mServiceProvider;
        private readonly ICarsRepository mCarsRepository;

        public HomeController(ILogger<HomeController> logger,
            IServiceProvider serviceProvider,
            ICarsRepository carsRepository)
        {
            _logger = logger;
            mServiceProvider = serviceProvider;
            mCarsRepository = carsRepository;
        }

        public IActionResult Index()
        {
            mCarsRepository.UpdateCar(new Car
            {
                Name = "Audi",
                Color = "Yellow"
            });

            var databaseCars = mCarsRepository.GetAll();

            return Ok(databaseCars);

            //return View();
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
