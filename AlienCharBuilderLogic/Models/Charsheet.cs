namespace AlienCharBuilderLogic.Models
{
    
    internal class Charactersheet
    {
        public string Agenda { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Career { get; set; } = string.Empty;
        public string Buddy { get; set; } = string.Empty;
        public string Rival { get; set; } = string.Empty;
        public string Appearance { get; set; } = string.Empty;

        public Talent myTalent { get; set; } = new Talent { };

        public List<TinyItem> Tiny_items { get; set; } = new List<TinyItem> { };
        public string Signature_item { get; set; } = string.Empty;
        public List<Gear> Gear { get; set; } = new List<Gear> { };

        public List<ICondition> Conditions { get; set; } = new List<ICondition> { };
        public Consumables Consumables { get; set; } = new Consumables();


        public List<Attribute> Attributes { get; set; } = AttributeInit.GetAttributes();

        public Armor Armor { get; set; } = new Armor();

        public List<Weapon> Weapons { get; set; } = new List<Weapon> { };


    }
}
