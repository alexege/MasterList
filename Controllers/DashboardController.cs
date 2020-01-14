using masterList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace masterList.Controllers
{
    public class DashboardController : UserAccessController
    {
        private MyContext dbContext;
        public DashboardController(MyContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            ViewBag.FirstName = HttpContext.Session.GetString("FirstName");
            ViewBag.LastName = HttpContext.Session.GetString("LastName");
            ViewBag.UserId = SessionUser;

            var words = dbContext.Words
                .ToList();

            // return View("Index", "Dashboard");
            return View(words);
        }

        [HttpPost("word/new")]
        public IActionResult AddWord(Word newWord)
        {
            if(ModelState.IsValid)
            {
                dbContext.Words.Add(newWord);
                dbContext.SaveChanges();
                System.Console.WriteLine(newWord.Title);
                System.Console.WriteLine(newWord.Definition);
                System.Console.WriteLine(newWord.Example);
                return RedirectToAction("Index", "Dashboard");
            }
            return View("Index", "Dashboard");
        }
    }
}