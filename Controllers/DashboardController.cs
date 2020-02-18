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

            var words = dbContext.Words.OrderBy(w => w.Title)
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
                // Note newNote = new Note();
                // newNote.WordId = newWord.WordId;
                // newNote.Content = "Dictionary";
                // dbContext.Notes.Add(newNote);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }
            return View("Index", "Dashboard");
        }

        [HttpPost("Word/{WordId}/Note/New")]
        public IActionResult AddNote([FromBody] Note newNote, int WordId)
        {
            if(ModelState.IsValid)
            {
                newNote.WordId = WordId;
                newNote.Word = dbContext.Words.FirstOrDefault(word => word.WordId == WordId);
                dbContext.Notes.Add(newNote);
                dbContext.SaveChanges();
                
                // return RedirectToAction("Index", "Dashboard");
                var words = dbContext.Words.OrderBy(w => w.Title)
                .Include(word => word.Notes)
                .ToList();

                // Reorder the notes so they stay in place
                words.ForEach(n => n.Notes = n.Notes.OrderBy(ni => ni.NoteId).ToList());

                return PartialView("WordPartial", words);
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

        [HttpPost("Word/{WordId}/Note/{NoteId}/Indent")]
        public IActionResult IndentNote(int WordId, int NoteId)
        {
            Note note = dbContext.Notes.FirstOrDefault(n => n.NoteId == NoteId);
            if(note.indentLevel < 9){
                note.indentLevel += 1;
            } else {
                note.indentLevel = 0;
            }
            dbContext.SaveChanges();
            return PartialView("ContentPartial", note);
        }
        
        [HttpPost("Word/{WordId}/Note/{NoteId}/Outdent")]
        public IActionResult OutdentNote(int WordId, int NoteId)
        {
            Note note = dbContext.Notes.FirstOrDefault(n => n.NoteId == NoteId);
            if(note.indentLevel > 0){
                note.indentLevel -= 1;
            }
            dbContext.SaveChanges();
            return PartialView("ContentPartial", note);
        }
        
        [HttpPost("Word/{WordId}/Note/{NoteId}/DeleteNote")]
        public IActionResult DeleteNote(int WordId, int NoteId)
        {
            Note noteToDelete = dbContext.Notes.FirstOrDefault(n => n.NoteId == NoteId);
            dbContext.Notes.Remove(noteToDelete);
            dbContext.SaveChanges();

            var words = dbContext.Words
                .OrderBy(word => word.Title)
                .Include(word => word.Notes)
                .ToList();
            return PartialView("WordPartial", words);
        }
    
        [HttpPost("Word/{WordId}/Note/{NoteId}/ChangeStyle")]
        public IActionResult ChangeNoteStyle(int WordId, int NoteId)
        {
            Note note = dbContext.Notes.FirstOrDefault(n => n.NoteId == NoteId);
            if(note.Style < 4){
                note.Style += 1;
            } else {
                note.Style = 0;
            }
            dbContext.SaveChanges();

            var words = dbContext.Words
                .OrderBy(word => word.Title)
                .Include(word => word.Notes)
                .ToList();

            // Reorder the notes so they stay in place
            words.ForEach(n => n.Notes = n.Notes.OrderBy(ni => ni.NoteId).ToList());

            return PartialView("WordPartial", words);
        }
       
        [HttpPost("Word/{WordId}/Note/{NoteId}/ChangeAlignment/{Position}")]
        public IActionResult ChangeAlignment(int WordId, int NoteId, int Position)
        {
            Note note = dbContext.Notes.FirstOrDefault(n => n.NoteId == NoteId);
            if(Position == 0){
                note.AlignPosition = 0;
            } else if(Position == 1){
                note.AlignPosition = 1;
            } else if(Position == 2){
                note.AlignPosition = 2;
            }
            dbContext.SaveChanges();

            var words = dbContext.Words
                .OrderBy(w => w.Title)
                .Include(word => word.Notes)
                .ToList();

            // Reorder the notes so they stay in place
            // words.ForEach(n => n.Notes = n.Notes.OrderBy(ni => ni.NoteId).ToList());
            words.ForEach(n => n.Notes = n.Notes.OrderBy(ni => ni.NoteId).ToList());
            
            return PartialView("WordPartial", words);
        }
    }
}