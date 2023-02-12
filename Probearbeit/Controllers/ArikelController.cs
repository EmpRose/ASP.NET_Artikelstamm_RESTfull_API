using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Probearbeit.Context;
using Probearbeit.Context.Kontext;
using Probearbeit.Context.Model;
using Probearbeit.Data;
using System.Net.Http;

namespace Probearbeit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArikelController : ControllerBase
    {
        //Datenbankverbindung => localhost: 44367/api/Artikel
        private readonly LibraryContext _db;
        private readonly VerboteneWorte _verboteneWorte;
        
        public ArikelController(LibraryContext context, VerboteneWorte verboteneWorte)
        {
            _db = context; _verboteneWorte = verboteneWorte; 
        }

        // CreateArtikel
        [HttpPost]
        public IActionResult CreateArtikel(Artikel artikel)
        {

            if (_verboteneWorte.IstVerbotenesWortEnthalten(artikel))
            {
                return BadRequest("Artikel enthält verbotenes Wort");
            }
            
            _db.Artikels.Add(artikel);
            _db.SaveChanges();

            return Ok("Artikel wurde erstellt");
        }

        // GetArtikelById
        [HttpGet("{id}")]
        public IActionResult GetArtikelById(int id)
        {
            // Find ist anwendbar, da die Id nur einmal vorkommt. Sonst SingleOrDefault();
            Artikel artikelFromDb = _db.Artikels.SingleOrDefault(a => a.Id == id);
            if (artikelFromDb == null)
            {
                return NotFound("Fehler: Artikel wurde nicht gefunden");
            }
            return Ok(artikelFromDb);
        }
        
        //GetByDateFromTo 
        [HttpGet("{start}/{ende}")]
        public IActionResult ZeitFilter(DateTime start, DateTime ende) 
        {
            var filteredArtikel = _db.Artikels.Where(a => a.ArtikelErstellt >= start && a.ArtikelErstellt <= ende).ToList();
            return Ok(filteredArtikel);
        }

        //GetArtikelByTitle
        [HttpGet("TitelSuche")]
        public ActionResult<IEnumerable<Artikel>> TitelSuche(string titel)
        {
            var artikel = _db.Artikels.Where(a => a.Sprache.Any(s => s.Titel.Contains(titel, StringComparison.OrdinalIgnoreCase))).ToList();

            if (artikel.Count == 0)
            {
                return NotFound();
            }

            return Ok(artikel);
        }
        
        // GetAllArtikel
        [HttpGet]
        public IActionResult GetAllArtikel()
        {
            return Ok(_db.Artikels.ToList());
        }

        // UpdateArtikel
        [HttpPut("{id}")]
        public IActionResult UpdateArtikel(int id, Artikel artikel)
        {
            /*if (id != artikel.Id)
            {
                return NotFound("Fehler: Artikel wurde nicht gefunden");
            }*/
            if (_verboteneWorte.IstVerbotenesWortEnthalten(artikel))
            {
                return BadRequest("Artikel enthält verbotenes Wort");
            }
            _db.Update(artikel);
            _db.SaveChanges();
            return Ok("Artikel erfolgreich verändert.");
        }

        // DeleteArtikelById
        [HttpDelete("{id}")]
        public IActionResult DeleteArtikel(int id)
        {
            Artikel artikelFromDb = _db.Artikels.SingleOrDefault(a => a.Id == id); ;
            if (artikelFromDb == null)
            {
                return NotFound("Fehler: Artikel wurde nicht gefunden");
            }
            _db.Artikels.Remove(artikelFromDb);
            _db.SaveChanges();
            return Ok();
        }
    }
}
