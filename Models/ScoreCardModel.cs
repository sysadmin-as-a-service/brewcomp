using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace BeerComp.Models
{
    public class ScoreCard
    {
        public int ID {get; set;}

        [Range(1,10)]
        [Required]
        [RegularExpression("^[0-9]*$",ErrorMessage="Please enter a whole number only.")]
        [DisplayFormat(DataFormatString="{0:0}")]
        public int TasteScore {get; set;}
       
        [Range(1,10)]
        [Required]
        [RegularExpression("^[0-9]*$",ErrorMessage="Please enter a whole number only.")]
        [DisplayFormat(DataFormatString="{0:0}")]
        public int LookScore {get; set;}

        [Range(1,10)]
        [Required]
        [RegularExpression("^[0-9]*$",ErrorMessage="Please enter a whole number only.")]
        [DisplayFormat(DataFormatString="{0:0}")]
        public int OtherScore {get; set;}

        [DisplayFormat(DataFormatString="{0:0.0}")]
        public double OverallScore {get; set;}
        
        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Comments {get; set;}

        [ForeignKey("Voter")]
        public int VoterID {get; set;}
        public virtual Voter Voter {get; set;}

        [ForeignKey("Entry")]
        public int EntryID {get; set;}
        public virtual BeerEntry Entry {get; set;}
        
    }
}