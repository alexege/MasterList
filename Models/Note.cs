using System.ComponentModel.DataAnnotations;

namespace masterList.Models
{
    public class Note
    {
        [Key]
        public int NoteId {get; set;}
        public int WordId { get; set; }

        // [MinLength(1, ErrorMessage="Content cannot be left blank")]
        public string Content { get; set; }
        public bool isBullet { get; set; }
        public int indentLevel { get; set; }
        public int Style { get; set; }
        public int AlignPosition { get; set; }
        public Word Word { get; set; }

        // Constructor
        public Note (){
            isBullet = false;
            Style = 0;
            indentLevel = 0;
            AlignPosition = 0;
        }
    }
}