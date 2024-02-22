using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{


    internal class Character
    {
        public int PlatoonNr { get; set; }

        [SheetnameAttribute(Sheetname = Constants.AGENDA)]
        public string Agenda { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.NAME)]
        public string Name { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.CAREER)]
        public string Career { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.BUDDY)]
        public string Buddy { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.RIVAL)]
        public string Rival { get; set; } = string.Empty;

        [SheetnameAttribute(Sheetname = Constants.APPEARANCE)]
        public string Appearance { get; set; } = string.Empty;

        [ComplexDataAttribute]
        public Conditions Conditions { get; set; } = new Conditions { };

        public Talent Talent { get; set; } = new Talent { };

        [ComplexDataAttribute]
        public TinyItems TinyItems { get; set; } = new TinyItems { };

        public string SignatureItem { get; set; } = string.Empty;

        [CountableAttribute(Min = 0, Max = 10)]

        public List<Gear> Gear { get; set; } = new List<Gear> { };

        public Consumables Consumables { get; set; } = new Consumables();

        [ComplexDataAttribute()]
        public Attribute Attributes { get; set; } = new Attribute();


        [ComplexDataAttribute()]
        public Armor Armor { get; set; } = new Armor();

        [CountableAttribute(Min = 0, Max = 4)]
        [ComplexDataAttribute()]
        public List<Weapon> Weapons { get; set; } = new List<Weapon> { };
    }
}
