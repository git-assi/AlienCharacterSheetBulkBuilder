using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{

    //https://chartopia.d12dev.com/chart/33313/
    public class Character
    {        
        public override string ToString()
        {
            string result = "";
            result = $"{Career} {Name} {Appearance}";
            return result;
        }


        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.AGENDA)]
        public string Agenda { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.NAME)]
        public string SheetName
        {
            get
            {
                return $"{Rank} {Name} ({Geschlecht})";
            }
        }

        public string Name { get; set; } = string.Empty;
        public string Geschlecht { get; set; } = string.Empty;        

        public string Rank { get; set; } = string.Empty;

        [ComplexDataAttribute]
        public required Career Career { get; set; }

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.BUDDY)]
        public string Buddy { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.RIVAL)]
        public string Rival { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.APPEARANCE)]
        public string Appearance { get; set; } = string.Empty;

        [ComplexDataAttribute]
        public required Conditions Conditions { get; set; }

        [ComplexDataAttribute]
        public required Talent Talent { get; set; }

        [ComplexDataAttribute]
        public required TinyItems TinyItems { get; set; }

        public string SignatureItem { get; set; } = string.Empty;

        [CountableAttribute(Min = 0, Max = 10)]
        public List<Gear> Gear { get; set; } = new List<Gear> { };

        public Consumables Consumables { get; set; } = new Consumables();

        [ComplexDataAttribute()]
        public Attribute Attributes { get; set; } = new Attribute();


        [ComplexDataAttribute()]
        public Armor Armor { get; set; } = new Armor();

        [CountableAttribute(Min = 0, Max = 4)]
        public List<Weapon> Weapons { get; set; } = new List<Weapon> { };
    }
}
