using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{


    public class Constants
    {
        public const string STRESS = "Stress";
        public const string HEATLH = "Heatlh";
        public const string XP = "XP";
        public const string RADIATION = "Radiation";

        public const string STARVING = "Starving";
        public const string DEHYDRATED = "Dehydrated";
        public const string EXHAUSTED = "Exhausted";
        public const string FREEZING = "Freezing";

        public const string RAD = "Rad";
        public const string CAD = "Cad";
    }

    internal class ConditionInit2
    {
    }

        internal class ConditionInit
    {
        [SheetnameAttribute(Sheetname = Constants.STRESS)]
        public int Stress { get; set; }

        [SheetnameAttribute(Sheetname = Constants.HEATLH)]
        public int Heatlh { get; set; }

        [SheetnameAttribute(Sheetname = Constants.CAD)]
        public int XP { get; set; }

        [SheetnameAttribute(Sheetname = Constants.RAD)]
        public int Radiation { get; set; }


    }
}

