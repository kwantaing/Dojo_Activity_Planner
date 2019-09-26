using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpBelt.Models
{
    public class Plan
    {
        [Key]
        public int plan_id{get;set;}
        public int activity_id{get;set;}
        public int user_id{get;set;}

        public Plan(int activity_id, int user_id)
        {
            this.activity_id = activity_id;
            this.user_id = user_id;
        }

        public DojoActivity Activity{get;set;}
        public User Participant{get;set;}
    }
}