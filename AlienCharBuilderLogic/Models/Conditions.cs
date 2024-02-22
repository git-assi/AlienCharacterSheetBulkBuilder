using AlienCharBuilderLogic.PropertyAttributes;
namespace AlienCharBuilderLogic.Models
{
    public class Conditions
    {
        [SheetnameAttribute(Sheetname = Constants.STARVING)]
        public bool Starving { get; set; }

        [SheetnameAttribute(Sheetname = Constants.DEHYDRATED)]
        public bool Dehydrated { get; set; }

        [SheetnameAttribute(Sheetname = Constants.EXHAUSTED)]
        public bool Exhausted { get; set; }

        [SheetnameAttribute(Sheetname = Constants.FREEZING)]
        public bool Freezing { get; set; }

        [SheetnameAttribute(Sheetname = Constants.STRESS)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int Stress { get; set; }

        [SheetnameAttribute(Sheetname = Constants.HEALTH)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int Health { get; set; }

        [SheetnameAttribute(Sheetname = Constants.CAD)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int XP { get; set; }

        [SheetnameAttribute(Sheetname = Constants.RAD)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int Radiation { get; set; }

        [SheetnameAttribute(Sheetname = Constants.ENCUMBRANCE)]
        public int Encumbrance { get; set; }

    }
}

