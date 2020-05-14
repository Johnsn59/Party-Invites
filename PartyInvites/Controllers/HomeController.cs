using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller // Inheritance, Extends
    {
        // F i e l d s

        private readonly ILogger<HomeController> _logger;

        // C o n t r o l l e r
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult HelloWorld()
        {
            ViewBag.X = "Xavier";
            ViewBag.R = "Ryan";

            if (DateTime.Now.Hour < 12)
            {
                ViewBag.Greeting = "Good Morning";
            }
            else if (DateTime.Now.Hour < 17)
            {
                ViewBag.Greeting = "Good Afternoon";
            }
            else
            {
                ViewBag.Greeting = "Good Evening";
            }

            IActionResult result = View();
            return result;
        }
        public IActionResult Index()
        {
            if (DateTime.Now.Hour < 12)
            {
                ViewBag.Greeting = "Good Morning";
            }
            else if (DateTime.Now.Hour < 17)
            {
                ViewBag.Greeting = "Good Afternoon";
            }
            else
            {
                ViewBag.Greeting = "Good Evening";
            }

            IActionResult result = View("MyView");
            return result;
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                FakeDB.AddResponse(guestResponse);
                return View("Thanks", guestResponse); // Thanks.cshtml
            }
            else
            {
                return View();
            }
        }
        public IActionResult ListResponses()
        {
            GuestResponse[] responses = FakeDB.GetResponses();
            return View(responses);
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
