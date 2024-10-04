using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    internal class ArmourFactory
    {
        private const string PFAD = @$".\GameResources\JSON\ArmorResources.json";

        private List<Armor> _armorTypes = new List<Armor>();

        public List<Armor> ArmorTypes 
        { 
            get
            {
                if (_armorTypes.Count == 0)
                {
                    _armorTypes = CreateArmorTypes();
                }
                return _armorTypes;
            }
            set
            {
                _armorTypes = value;
            }
        }

        public Armor GetRandomArmor(int rando)
        {            
            if (rando == 10)
            {
                rando = 3;
            }
            else if (rando >= 8)
            {
                rando = 2;
            }
            else if (rando == 7)
            {
                rando = 1;
            }
            else
            {
                rando = 0;
            }
            return ArmorTypes[rando];
        }

        public List<Armor> CreateArmorTypes()
        {
            return new List<Armor> {
            new Armor() { Name = "Armat M3 Körperpanzerung", Rating = 6, Luft = 0, Gewicht = 1 },
            new Armor() { Name = "IRC Mk. 50 Kompressionsanzug", Rating = 2, Luft = 5, Gewicht = 1 },
            new Armor() { Name = "IRC Mk. 35 Druckanzug", Rating = 5, Luft = 4, Gewicht = 2, Special = { Constants.Armor.GESCHICKLICHKEIT_MINUS_EINS } },
            new Armor() { Name = "Eco All-World Systems Überlebensanzug", Rating = 4, Luft = 6, Gewicht = 2 },
            new Armor() { Name = "Weyland-Yutani APE-Anzug", Rating = 3, Luft = 4, Gewicht = 1, Special = { Constants.Armor.UEBERLEBEN_PLUS_DREI } },
            };
        }

        public Dictionary<string, List<Weapon>> LoadWeaponResources()
        {
            var x = InGameResources.JSONConverter.ReadJsonFromFile<Dictionary<string, List<Weapon>>>(PFAD);
            return x;
        }

        public void SaveWeaponResources(Dictionary<string, List<Weapon>> weapons)
        {
            InGameResources.JSONConverter.WriteObjectToJsonFile(PFAD, weapons);
        }
    }
}
