using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TelefoaneOnline.Models
{
    public class Memorie
    {
        public int ID { get; set; }
        [Display(Name = "Memorie Produs")]
        public string MemorieProdus { get; set; }
        public ICollection<MemorieInterna>? MemoriiInterne { get; set; }
    }
}