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
                .Include(word => word.Notes)
                .ToList();

            // var notes = dbContext.Notes
            //     .Include(note => note.Word)
            //     .ToList();

            return View(words);
            // return View(notes);
        }

        [HttpPost("Word/New")]
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

        [HttpPost("Word/Note/New")]
        public IActionResult AddNote(Note newNote, int WordId)
        {
            if(ModelState.IsValid)
            {
                newNote.WordId = WordId;
                newNote.Word = dbContext.Words.FirstOrDefault(word => word.WordId == WordId);
                dbContext.Notes.Add(newNote);
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
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index");
        }
        
        [HttpPost("Word/{WordId}/UpdateNote/{NoteId}")]
        public IActionResult UpdateNote([FromBody] Note editNote, int WordId, int NoteId)
        {
            Note noteToEdit = dbContext.Notes
                .FirstOrDefault(n => n.NoteId == NoteId);

            if(ModelState.IsValid)
            {
                noteToEdit.Content = editNote.Content;
                dbContext.SaveChanges();

                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index");
        }
        
        [HttpDelete("Word/{WordId}/DeleteNote/{NoteId}")]
        public IActionResult DeleteNote([FromBody] Note editNote, int WordId, int NoteId)
        {
            Note noteToDelete = dbContext.Notes
                .FirstOrDefault(n => n.NoteId == NoteId);
            dbContext.Notes.Remove(noteToDelete);
            dbContext.SaveChanges();

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

        [HttpPost("Word/{WordId}/Note/{NoteId}/ToggleBullets")]
        public IActionResult ToggleBullets(int WordId, int NoteId)
        {
            Note note = dbContext.Notes.FirstOrDefault(n => n.NoteId == NoteId);
            if(note.isBullet == false){
                note.isBullet = true;
            } else {
                note.isBullet = false;
            }
            dbContext.SaveChanges();
            // return RedirectToAction("Index");
            return PartialView("ContentPartial", note);
        }

        // note.indentLevel += 1;
    }
}