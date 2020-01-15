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

            return View(words);
        }

        [HttpPost("word/new")]
        public IActionResult AddWord(Word newWord)
        {
            if(ModelState.IsValid)
            {
                dbContext.Words.Add(newWord);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            return View("Index", "Dashboard");
        }

        [HttpPost("Word/UpdateTitle/{WordId}")]
        public IActionResult UpdateWordTitle(Word editWord, int WordId)
        {
            Word wordToEdit = dbContext.Words
                .FirstOrDefault(w => w.WordId == WordId);
            if(ModelState.IsValid)
            {
                wordToEdit.Title = editWord.Title;
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost("Word/UpdateDefinition/{WordId}")]
        public IActionResult UpdateWordDefinition(Word editWord, int WordId)
        {
            Word wordToEdit = dbContext.Words
                .FirstOrDefault(w => w.WordId == WordId);

            if(ModelState.IsValid)
            {
                wordToEdit.Definition = editWord.Definition;
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost("Word/UpdateExample/{WordId}")]
        public IActionResult UpdateWordExample(Word editWord, int WordId)
        {
            Word wordToEdit = dbContext.Words
                                .FirstOrDefault(w => w.WordId == WordId);

            if(ModelState.IsValid)
            {
                wordToEdit.Example = editWord.Example;
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("Word/Delete/{WordId}")]
        public IActionResult DeleteWord(int WordId)
        {
            Word wordToDelete = dbContext.Words.FirstOrDefault(w => w.WordId == WordId);
            dbContext.Words.Remove(wordToDelete);
            dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}