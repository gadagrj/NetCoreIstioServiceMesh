using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreIstio.Web.Models;
using NetCoreIstio.Web.Service;

namespace NetCoreIstio.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserServiceClient UserClient;

        public HomeController(IUserServiceClient userClient)
        {
            this.UserClient = userClient;

        }
        public async Task<IActionResult> Index()
        {
            var users = await UserClient.GetUserAsync();
            var usersViewModel = users.Select(x => new UserViewModel
            {
                id = x.id,
                Name = x.Name,
                description = x.description
            }).ToList();
            return View(usersViewModel);
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
