using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace Probearbeit.Context.Kontext
{

    public class SpracheKontext
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Beschreibung { get; set; }
        [Required]
        public string Titel { get; set; }
        
        [Required]
        public Sprachen Sprache { get; set; }
    }
}