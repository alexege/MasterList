using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using masterList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace masterList.Controllers
{
    // Store active user in session
    public abstract class UserAccessController : Controller
    {
        protected int? SessionUser
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
    }

    public class HomeController : UserAccessController
    {
        private MyContext dbContext;
		// here we can "inject" our context service into the constructor
		public HomeController(MyContext context)
		{
			dbContext = context;
		}

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(User newUser)
        {
            if(ModelState.IsValid)
            {
                bool notUnique = dbContext.Users.Any(a => a.Email == newUser.Email);

                if(notUnique)
                {
                    ModelState.AddModelError("Email", "Email already in use. Please use a new one");
                    return View("Index");
                }

                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hash = hasher.HashPassword(newUser, newUser.Password);
                newUser.Password = hash;

                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();

                // var last_added_User = dbContext.Users.Last().UserId;
                // HttpContext.Session.SetInt32("UserId", last_added_User);

                SessionUser = newUser.UserId;
            
                return RedirectToAction("Index", "Dashboard");
            }
        return View("Index");
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginUser loginUser)
        {
            var found_user = dbContext.Users.FirstOrDefault(user => user.Email == loginUser.LoginEmail);

            if(found_user == null)
            {
                ModelState.AddModelError("LoginEmail", "Incorrect Email or Password");
                return View("Index");
            }

            PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
            var user_verified = Hasher.VerifyHashedPassword(loginUser, found_user.Password, loginUser.LoginPassword);

            if(user_verified == 0)
            {
                ModelState.AddModelError("LoginEmail", "Email already in use. Please use a new one");
                return View("Index");
            }

            SessionUser = found_user.UserId;
            
            return RedirectToAction("Index", "Dashboard");
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
