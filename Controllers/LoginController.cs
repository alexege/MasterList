using masterList.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace masterList.Controllers
{
    public class LoginController : UserAccessController
    {
        public IActionResult Index()
        {
            return View("Index", "Home");
        }

        // [HttpPost("Register")]
        // public IActionResult Register(User newUser)
        // {
        //     if(ModelState.IsValid)
        //     {
        //         bool notUnique = DbContext.Users.Any(a => a.Email == newUser.Email);

        //         if(notUnique)
        //         {
        //             ModelState.AddModelError("Email", "Email already in use. Please use a new one");
        //             return View("Index");
        //         }

        //         PasswordHasher<User> hasher = new PasswordHasher<User>();
        //         string hash = hasher.HashPassword(newUser, newUser.Password);
        //         newUser.Password = hash;

        //         dbContext.Users.Add(newUser);
        //         dbContext.SaveChanges();

        //         var last_added_User = dbContext.Users.Last().UserId;
        //         HttpContext.Session.SetInt32("UserId", last_added_User);
            
        //         return RedirectToAction("Dashboard");
        //     }
        // return View("Index");
        // }

        // [HttpPost("Login")]
        // public IActionResult Login(LoginUser loginUser)
        // {
        //     var found_user = dbContext.Users.FirstOrDefault(user => user.Email == LoginUser.LogEmail);

        //     if(found_user == null)
        //     {
        //         ModelState.AddModelError("LogEmail", "Incorrect Email or Password");
        //         return View("Index");
        //     }

        //     PasswordHasher<LoginUser> Hasher = new PasswordHasher<LoginUser>();
        //     var user_verified = Hasher.VerifyHashedPassword(loginUser, found_user.Password, loginUser.LogPassword);

        //     if(user_verified == 0)
        //     {
        //         ModelState.AddModelError("LogEmail", "Email already in use. Please use a new one");
        //         return View("Index");
        //     }

        //     var current_user = dbContext.Users.Last().UserId;

        //     HttpContext.Session.SetInt32("UserId", dbContext.Users.Last().UserId);
            
        //     return RedirectToAction("Dashboard");
        // }
    }
}