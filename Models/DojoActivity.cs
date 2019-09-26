using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpBelt.Models
{
    public class DojoActivity
    {
        [Key]
        public int activity_id{get;set;}
        [Required(ErrorMessage="Please enter a name for the activity.")]
        [MinLength(2,ErrorMessage="Activity name needs to have at least 2 characters.")]
        public string name{get;set;}
        [Required(ErrorMessage="Please enter a description.")]
        [MinLength(10, ErrorMessage="Description needs to have at least 10 characters.")]
        public string description{get;set;}

        [Required(ErrorMessage= "Please enter a date.")]
        [DateCheck]
        public DateTime date{get;set;}

        [Required(ErrorMessage="Please enter a time.")]
        public TimeSpan time{get;set;}

        [Required(ErrorMessage="Please enter a duration.")]
        public int duration{get;set;}
        [Required]
        public string durationType{get;set;}
        public int coordinator_id{get;set;}

        //Navigation Properties

        public User Coordinator{get;set;}
        public List<Plan> Plans{get;set;}
        
        public DateTime fullTime{get{
            DateTime full = this.date + this.time;
            return full;
        }}
        public class DateCheckAttribute : ValidationAttribute{
        
        protected override ValidationResult IsValid(object date, ValidationContext validationContext){
            DateTime day = Convert.ToDateTime(date);
            DateTime now  =  DateTime.Now;
            if(day<now){
                return new ValidationResult("Activity must be in the future!");
            }else{
                return ValidationResult.Success;
            }
        }
    }
    }
}