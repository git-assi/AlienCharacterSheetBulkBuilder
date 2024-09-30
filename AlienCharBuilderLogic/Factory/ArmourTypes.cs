using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    internal class Armors
    {
        public List<Armor> ArmorTypes = new()
        {
            new Armor() { Name = "Armat M3 Körperpanzerung", Rating = 6, Luft = 0, Gewicht = 1 },
            new Armor() { Name = "IRC Mk. 50 Kompressionsanzug", Rating = 2, Luft = 5, Gewicht = 1 },
            new Armor() { Name = "IRC Mk. 35 Druckanzug", Rating = 5, Luft = 4, Gewicht = 2, Special = { Constants.Armor.GESCHICKLICHKEIT_MINUS_EINS } },            
            new Armor() { Name = "Eco All-World Systems Überlebensanzug", Rating = 4, Luft = 6, Gewicht = 2 },
            new Armor() { Name = "Weyland-Yutani APE-Anzug", Rating = 3, Luft = 4, Gewicht = 1, Special = { Constants.Armor.UEBERLEBEN_PLUS_DREI } },
        };
    }
}
