using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BeerComp.Models
{
        public class BeerEntry
        {
            public int ID {get; set;}
            public string EntryName {get; set;}

            [Range(0,100)]
            public double ABV {get; set;}
            public BeerCategory Category {get; set;}

            [ForeignKey("Owner")]
            public int OwnerID {get; set;}

            public virtual Owner Owner {get; set;}

        }
}