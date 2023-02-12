
//using Probearbeit.Context.Interfaces;
using Probearbeit.Context.Kontext;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Probearbeit.Context
{


    public class Artikel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime ArtikelErstellt { get; set; } = DateTime.UtcNow;
        [Required]
        public List<SpracheKontext> Sprache { get; set; }
        [Required]
        public bool Sperrgut { get; set; }
        [Required]
        public string Farbe { get; set; }
        public string Batterietyp { get; set; }
        public string Marke { get; set; }

        public bool istFertig = false;

    }
} 


