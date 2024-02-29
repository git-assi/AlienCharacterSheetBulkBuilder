using AlienCharBuilderLogic.PropertyAttributes;
namespace AlienCharBuilderLogic.Models
{
    public class Conditions
    {
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.STARVING)]
        public bool Starving { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.DEHYDRATED)]
        public bool Dehydrated { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.EXHAUSTED)]
        public bool Exhausted { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.FREEZING)]
        public bool Freezing { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.STRESS)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int Stress { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.HEALTH)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int Health { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.CAD)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int XP { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.RAD)]
        [MinMaxAttribute(Max = 10, Min = 0)]
        public int Radiation { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.ENCUMBRANCE)]
        public string Encumbrance { get; set; } = string.Empty;

    }
}

