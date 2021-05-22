using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeerComp.Models
{
        public class Owner
        {
            public int ID {get; set;}

            [DataType(DataType.EmailAddress)]
            public string Email {get; set;}

        }

}