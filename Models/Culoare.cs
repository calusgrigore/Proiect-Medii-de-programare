using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TelefoaneOnline.Models
{
    public class Culoare
    {
        public int ID { get; set; }
        [Display(Name = "Culoare Produs")]
        public string CuloareProdus { get; set; }
        public ICollection<Telefon>? Telefoane { get; set; }
    }
}