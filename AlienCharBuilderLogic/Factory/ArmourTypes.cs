using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    internal class Armors
    {        
        public List<Armor> ArmorTypes = new()
        {
            new Armor() { Name = "Flakvest", Rating = 5 },
            new Armor() { Name = "EVA Suit", Rating = 1 },
            new Armor() { Name = "EXO Suit", Rating = 3 },
            new Armor() { Name = "Clothes", Rating = 0 },
        };
    }
}
