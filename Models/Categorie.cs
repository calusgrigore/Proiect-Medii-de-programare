using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TelefoaneOnline.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Categorie Produs")]
        public string CategorieProdus { get; set; }
        public ICollection<Telefon>? Telefoane { get; set; }
    }
}