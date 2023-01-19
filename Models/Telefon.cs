//using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace TelefoaneOnline.Models
{
    public class Telefon
    {
        public int ID { get; set; }
        public string Denumire { get; set; }
        [Range(0.01, 7000)]
        public decimal Pret { get; set; }
        public string Model { get; set; }
        [Display(Name = "Diagonala Display")]
        public string DiagDisplay { get; set; }

        public int? CategorieID { get; set; }
        public Categorie? Categorie { get; set; }

        public int? MemorieID { get; set; }
        public Memorie? Memorie { get; set; }

        public int? CuloareID { get; set; }
        public Culoare? Culoare { get; set; }

        // public ICollection<MemorieInterna>? MemoriiInterne { get; set; }
    }
}