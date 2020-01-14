using System.ComponentModel.DataAnnotations;

namespace masterList.Models
{
    public class Word
    {
        [Key]
        public int WordId {get; set;}

        [Required(ErrorMessage="Title is required.")]
        public string Title { get; set; }

        public string Image { get; set; }

        public string Definition { get; set; }

        public string Example { get; set; }
    }
}