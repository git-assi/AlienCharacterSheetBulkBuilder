using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.InGameResources
{
    internal class GearResourcesFactory
    {
        public List<Gear> Gears { get; set; } = new List<Gear>();

        public List<Gear> CreateDefaultGear()
        {
            return new List<Gear>() {
                new Gear() { Name = "Schneidbrenner", Weight = 2 },
                new Gear() { Name = "Schraubenzieher", Weight = 0.5 },
                new Gear() { Name = "Feuerzeug", Weight = 0.1 },
                new Gear() { Name = "Taschenlampe" , Weight = 0.2 },
                new Gear() { Name = "Bindfaden" },
                };
        }

        public List<Gear> GetRandomGear()
        {
            return CreateDefaultGear();
        }
    }
}
