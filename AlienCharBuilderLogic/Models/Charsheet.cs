using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    

    internal class Charactersheet
    {
        public int PlatoonNr { get; set; }
        private Dictionary<string, int> _items { get; set; } = new Dictionary<string, int>();

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

        public Conditions Conditions { get; set; } = new Conditions { };

        public Talent myTalent { get; set; } = new Talent { };

        public TinyItems Tiny_items { get; set; } = new TinyItems { };
        
        public string Signature_item { get; set; } = string.Empty;
        
        public List<Gear> Gear { get; set; } = new List<Gear> { };

        public Consumables Consumables { get; set; } = new Consumables();
       
        public Armor Armor { get; set; } = new Armor();

        public List<Weapon> Weapons { get; set; } = new List<Weapon> { };


    }
}
