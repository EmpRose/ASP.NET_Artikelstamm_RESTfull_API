namespace Probearbeit.Context.Model
{
    public class VerboteneWorte
    { 
        public bool IstVerbotenesWortEnthalten(Artikel artikel)
        {
            foreach (var spracheKontext in artikel.Sprache)
            {
                if (verboteneWorte.Any(wort => spracheKontext.Beschreibung.Contains(wort) || spracheKontext.Titel.Contains(wort)))
                {
                    return true;
                }
            }

            return false;
        }

        private List<string> verboteneWorte = new List<string>
        {
            "Obszönität",
            "Gewalt",
            "Rassismus",
            "Diskriminierung"
        };
    }
}
