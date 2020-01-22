using masterList.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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
        
        [HttpPost("Word/UpdateWord/{WordId}")]
        public IActionResult UpdateWord([FromBody] Word editWord, int WordId)
        {
            Word wordToEdit = dbContext.Words
                .FirstOrDefault(w => w.WordId == WordId);

            if(ModelState.IsValid)
            {
                wordToEdit.Title = editWord.Title;
                wordToEdit.Definition = editWord.Definition;
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