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
        private readonly CarMapper mCarMapper;

        public HomeController(ILogger<HomeController> logger,
            IServiceProvider serviceProvider,
            ICarsRepository carsRepository,
            CarMapper carMapper)
        {
            _logger = logger;
            mServiceProvider = serviceProvider;
            mCarsRepository = carsRepository;
            mCarMapper = carMapper;
        }

        public IActionResult Index()
        {
            var car = mCarsRepository.GetSettingByName("Porshe");

            var dataModelSetting = mCarMapper.Map(car);

            dataModelSetting.Color = "brown";

            mCarsRepository.SaveChanges();

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
