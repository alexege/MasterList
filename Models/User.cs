using System;
using System.ComponentModel.DataAnnotations;

namespace masterList.Models
{
    public class User
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int UserId { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class LoginUser
    {
        [EmailAddress]
        public string LoginEmail {get; set;}
        public string LoginPassword {get; set;}
    }
}