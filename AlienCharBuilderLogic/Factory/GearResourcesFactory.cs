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

        public List<Gear> GetRandomGear(string career)
        {
            var result = new List<Gear>();
            switch (career)
            {
                case Constants.Career.DRIVER:
                    result.AddRange(new List<Gear>() {                
                                    new Gear() { Name = "Sonnenbrille", Weight = 0.2 },
                                    new Gear() { Name = "Feuerzeug", Weight = 0.1 },                
                                    });
                    break;
                case Constants.Career.MARINE:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Taschenlampe", Weight = 0.2 },
                                    new Gear() { Name = "Schraubenzieher", Weight = 0.1 },
                                    });

                    break;
                case Constants.Career.PILOT:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Sonnenbrille", Weight = 0.2 },
                                    new Gear() { Name = "Glückbringer" },
                                    });
                    break;                    
                case Constants.Career.HEAVY_GUNNER:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Waffen Reinigungskit", Weight = 0.2 },
                                    new Gear() { Name = "Kautabak", Weight = 0.5 },
                                    });
                    break;
                case Constants.Career.MEDIC:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Wasserflasche", Weight = 0.2 },
                                    new Gear() { Name = "Decke", Weight = 0.5 },
                                    });
                    break;
                case Constants.Career.TECH:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Tablet", Weight = 0.2 },
                                    new Gear() { Name = "Elektrowerkzeug", Weight = 0.5 },
                                    });
                    break;
                case Constants.Career.WEAPONS_OFFICER:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Energydrink", Weight = 0.2 },
                                    new Gear() { Name = "Kaugummi"},
                                    });
                    break;
                case Constants.Career.OFFICER:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Tablet", Weight = 0.2 },
                                    new Gear() { Name = "Lesebrille"},
                                    });
                    break;
                case Constants.Career.SERGANT:
                    result.AddRange(new List<Gear>() {
                                    new Gear() { Name = "Zigarren", Weight = 0.2 },                                    
                                    });
                    break;

            }

            return result;

        }

    }
}

