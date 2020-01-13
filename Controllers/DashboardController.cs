using masterList.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace masterList.Controllers
{
    public class DashboardController : UserAccessController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}