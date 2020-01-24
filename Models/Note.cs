using System.ComponentModel.DataAnnotations;

namespace masterList.Models
{
    public class Note
    {
        [Key]
        public int NoteId {get; set;}
        public int WordId { get; set; }
        public string Content { get; set; }
        public bool isBullet { get; set; }
        public int indentLevel { get; set; }
        public Word Word { get; set; }

        // Constructor
        public Note (){
            isBullet = false;
            indentLevel = 0;
        }
    }
}