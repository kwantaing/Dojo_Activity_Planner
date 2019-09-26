using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpBelt.Models{
    
    public class User{
        [Key]
        public int user_id{get;set;}
        [Required(ErrorMessage="Please enter a name.")]
        [MinLength(2, ErrorMessage="Name need to be at least 2 characters.")]
        public string name{get;set;}
    
        [Required(ErrorMessage="Please enter a valid email.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string email{get;set;}

        [Required(ErrorMessage="Please enter a password.")]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.{8,})(?=.*[0-9])(?=.*[A-Za-z])(?=.*[!@#$%^&+=]).*$",ErrorMessage="Please ensure the password has at least one each: number, letter, character, as well as at least 8 characters.")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters!")]
        public string password{get;set;}

        [Required(ErrorMessage="Please confirm your password.")]
        [Compare("password",ErrorMessage="Passwords must match.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string pwConfirm{get;set;}
        [DataType(DataType.DateTime)]
        public DateTime created_at{get;set;}

        [DataType(DataType.DateTime)]
        public DateTime updated_at{get;set;}

        //Navigation Properties
        public List<Plan> Plans{get;set;}

        



    }
}