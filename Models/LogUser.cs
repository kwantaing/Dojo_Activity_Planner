using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpBelt.Models{
    
    public class LogUser{
        [Required(ErrorMessage="Please enter a valid email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string logEmail{get;set;}

        [Required(ErrorMessage="Please enter the password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be 8 characters or more!")]
        public string logPassword{get;set;}




    }
}