using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace masterList.Models
{
    public class User
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int UserId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
       [Required(ErrorMessage="First Name is required.")]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last Name is required.")]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be as least 8 characters long.")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Confirm_Password { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }
    }

    public class LoginUser
    {
        [EmailAddress]
        public string LoginEmail {get; set;}
        public string LoginPassword {get; set;}
    }
}