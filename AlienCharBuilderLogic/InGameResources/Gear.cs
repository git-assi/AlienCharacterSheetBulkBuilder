using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.InGameResources
{
    internal class GearResources
    {
        public static List<Gear> Generic = new List<Gear>()
        {
                new Gear() { Name = "Schneidbrenner", Weight = 2 },
                new Gear() { Name = "Schraubenzieher", Weight = 0.5 },
                new Gear() { Name = "Feuerzeug", Weight = 0.1 },
                new Gear() { Name = "Taschenlampe" , Weight = 0.2 },
                new Gear() { Name = "Bindfaden" },
        };
    }
}
