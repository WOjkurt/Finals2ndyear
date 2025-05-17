using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using JwtAuthDemo.Models.Entities;

namespace JwtAuthDemo.Models.Info
{
    public class PersonalInformation
    {
        public int Id { get; set; }
        public DateTime BirthDate { get; set; }
        public string Religion { get; set; } = string.Empty;
        public string Citizenship { get; set; } = string.Empty;
        public string PermanentAddress { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string BloodType { get; set; }
 
        public string PersonContactedInCaseOfEmergency { get; set; } = string.Empty;
 
        public int ContactNumber { get; set; }
 

        public Employee Employee { get; set; }

    }
}