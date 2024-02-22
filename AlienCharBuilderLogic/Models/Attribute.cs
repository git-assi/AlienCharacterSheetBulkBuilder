using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Attribute
    {
        public string Name { get; set; } = string.Empty;
        public string Sheetname { get; set; } = string.Empty;
        public int Value { get; set; }
    }

    public class Fubar
    {
        [SheetnameAttribute(Sheetname = Constants.STRENGTH)]
        public int Strength { get; set; }

        [SheetnameAttribute(Sheetname = Constants.AGILITY)]
        public int Agility { get; set; }

        [SheetnameAttribute(Sheetname = Constants.WITS)]
        public int Wits { get; set; }

        [SheetnameAttribute(Sheetname = Constants.EMPATHY)]
        public int Empathy { get; set; }

        [SheetnameAttribute(Sheetname = Constants.HEAVY_MACHINERY)]
        public int HeavyMachinery { get; set; }

        [SheetnameAttribute(Sheetname = Constants.CLOSE_COMBAT)]
        public int CloseCombat { get; set; }

        [SheetnameAttribute(Sheetname = Constants.STAMINA)]
        public int Stamina { get; set; }

        [SheetnameAttribute(Sheetname = Constants.OBSERVATION)]
        public int Observation { get; set; }

        [SheetnameAttribute(Sheetname = Constants.SURVIVAL)]
        public int Survival { get; set; }

        [SheetnameAttribute(Sheetname = Constants.COMTECH)]
        public int Comtech { get; set; }

        [SheetnameAttribute(Sheetname = Constants.MEDICALAID)]
        public int MedicalAid { get; set; }

        [SheetnameAttribute(Sheetname = Constants.MANIPULATION)]
        public int Manipulation { get; set; }

        [SheetnameAttribute(Sheetname = Constants.COMMAND)]
        public int Command { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PILOTING)]
        public int Piloting { get; set; }

        [SheetnameAttribute(Sheetname = Constants.MOBILTY)]
        public int Mobilty { get; set; }

        [SheetnameAttribute(Sheetname = Constants.RANGED_COMBAT)]
        public int RangedCombat { get; set; }

        [SheetnameAttribute(Sheetname = Constants.ENCUMBRANCE)]
        public int Encumbrance { get; set; }
    }

    
}
