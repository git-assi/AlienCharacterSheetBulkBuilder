using AlienCharBuilderLogic.PropertyAttributes;
using AlienCharBuilderLogic.Constants;


//StartAttribute in Summe 14
//Hauptattribut (durch Klasse) darf max 5
//Fertigkeiten 10 
//Fertigkeiten +1 Hauptfertigkeiten +3 bei Start

namespace AlienCharBuilderLogic.Models
{
    public class Attribute
    {
        public int AttributesSum
        {
            get
            {
                return Strength.Value + Agility.Value + Wits.Value + Empathy.Value;
            }
        }

        public int SkillSum
        {
            get
            {
                return 0;// Strength.SkillSum + Agility.SkillSum + Wits.SkillSum + Empathy.SkillSum;
            }
        }

        [ComplexDataAttribute]
        public Strength Strength { get; set; } = new Strength();

        [ComplexDataAttribute]
        public Agility Agility { get; set; } = new Agility();

        [ComplexDataAttribute]
        public Wits Wits { get; set; } = new Wits();
        
        [ComplexDataAttribute]
        public Empathy Empathy { get; set; } = new Empathy();
    }
    public interface ISkill
    {

    }
    public class Strength : ISkill
    {
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.STRENGTH)]
        [MinMaxAttribute(Min = 2, Max = 4)]
        public int Value { get; set; }

        private int _closeCombat;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.CLOSE_COMBAT)]
        public int CloseCombat
        {
            get
            {
                return Value + _closeCombat;
            }
            set
            {
                _closeCombat += value;
            }
        }

        private int _stamina;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.STAMINA)]
        public int Stamina
        {
            get
            {
                return Value + _stamina;
            }
            set
            {
                _stamina += value;
            }
        }

        private int _heavyMachinery;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.HEAVY_MACHINERY)]
        public int HeavyMachinery
        {
            get
            {
                return Value + _heavyMachinery;
            }
            set
            {
                _heavyMachinery += value;
            }
        }
    }

    public class Agility
    {
        [MinMaxAttribute(Min = 2, Max = 4)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.AGILITY)]        
        public int Value { get; set; }

        private int _piloting;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.PILOTING)]
        public int Piloting
        {
            get
            {
                return Value + _piloting;
            }
            set
            {
                _piloting += Value;
            }
        }

        private int _mobilty;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.MOBILTY)]
        public int Mobilty
        {
            get
            {
                return Value + _mobilty;
            }
            set
            {
                _mobilty += Value;
            }
        }

        public int _rangedCombat;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.RANGED_COMBAT)]
        public int RangedCombat
        {
            get
            {
                return Value + _rangedCombat;
            }
            set
            {
                _rangedCombat += Value;
            }
        }
    }

    public class Empathy
    {
        [MinMaxAttribute(Min = 2, Max = 4)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.EMPATHY)]
        public int Value { get; set; }

        private int _medicalAid;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.MEDICALAID)]
        public int MedicalAid
        {
            get
            {
                return Value + _medicalAid;
            }
            set
            {
                _medicalAid += value;
            }
        }

        private int _manipulation;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.MANIPULATION)]
        public int Manipulation
        {
            get
            {
                return Value + _manipulation;
            }
            set
            {
                _manipulation += value;
            }
        }

        private int _command;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.COMMAND)]
        public int Command
        {
            get
            {                
                return Value + _command;
            }
            set
            {                
                _command += value;
            }
        }

    }

    public class Wits
    {
        [MinMaxAttribute(Min = 2, Max = 4)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.WITS)]
        public int Value { get; set; }

        private int _observation;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.OBSERVATION)]
        public int Observation
        {
            get
            {
                return Value + _observation;
            }
            set
            {
                _observation += value;
            }
        }

        private int _survival;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.SURVIVAL)]
        public int Survival
        {
            get
            {
                return Value + _survival;
            }
            set
            {
                _survival += value;
            }
        }

        private int _comtech;
        [MinMaxAttribute(Min = 0, Max = 5)]
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.COMTECH)]
        public int Comtech
        {
            get
            {
                return Value + _comtech;
            }
            set
            {
                _comtech += Value;
            }
        }
    }


}
