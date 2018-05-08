using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiPractice.Models;

namespace ApiPractice.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetGithubProfile()
        {
            var userProfile = GithubProfile.GetGithubProfile();
            return View(userProfile);
        }

        public IActionResult GetProfile()
        {
            var userProfile = GithubProfile.GetProfile();
            return View(userProfile);
        }

        public IActionResult Send()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
