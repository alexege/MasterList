using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace masterList.Models
{
    public class Word
    {
        [Key]
        public int WordId {get; set;}
        public string Title { get; set; }
        public List<Note> Notes { get; set; }
    }
}