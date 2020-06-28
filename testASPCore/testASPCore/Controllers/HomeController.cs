using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testASPCore.Models;
using testASPCore.Models.DAL;
using testASPCore.Services;

namespace testASPCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var service = new PhoneService();
            var result = service.GetAll();
            if(result == null)
            {
                return View();
            }
            return View(result);
        }
    }
}
