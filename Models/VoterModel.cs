using System;
using System.ComponentModel.DataAnnotations;

namespace BeerComp.Models
{
    public class Voter
    {
        public int ID {get; set;}
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;}
    }
}