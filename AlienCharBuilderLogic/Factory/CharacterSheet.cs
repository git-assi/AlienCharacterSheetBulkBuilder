using AlienCharBuilderLogic.InGameResources;
using AlienCharBuilderLogic.Models;
using AlienCharBuilderLogic.PropertyAttributes;
using System.Linq;


namespace AlienCharBuilderLogic.Factory
{
    internal class CharacterFactory
    {
        private static readonly Random RandomGen = new();

        public string platoon { get; set; } = string.Empty;

        public Character CreateCharacter(string career)
        {
            var newCharacter = new Character();
            (string name, string geschlecht) = GetNameUndGeschlecht();
            newCharacter.Appearance = geschlecht + " " + platoon + " Platoon";
            newCharacter.Name = name;
            newCharacter.Career = career;

            newCharacter.Armor = GetRandomArmor();
            newCharacter.Talent = GetRandomGenericTalent();
            newCharacter.Weapons = GetRandomWeapons();
            newCharacter.Gear = GetRandomGear();

            newCharacter.TinyItems.AddItem("Foto");
            newCharacter.TinyItems.AddItem("Zigarette");
            newCharacter.TinyItems.AddItem("Zigarette");
            newCharacter.TinyItems.AddItem("Zigarette");
            newCharacter.TinyItems.AddItem("Zigarette");

            newCharacter.Attributes.Wits.Value = randoIntAttribute();
            newCharacter.Attributes.Wits.Survival = randoIntAttribute();
            newCharacter.Attributes.Wits.Comtech = randoIntAttribute();
            newCharacter.Attributes.Wits.Observation = randoIntAttribute();

            newCharacter.Attributes.Agility.Value = randoIntAttribute();
            newCharacter.Attributes.Agility.Piloting = randoIntAttribute();
            newCharacter.Attributes.Agility.RangedCombat = randoIntAttribute();
            newCharacter.Attributes.Agility.Mobilty = randoIntAttribute();

            newCharacter.Attributes.Strength.Value = randoIntAttribute();
            newCharacter.Attributes.Strength.HeavyMachinery = randoIntAttribute();
            newCharacter.Attributes.Strength.Stamina = randoIntAttribute();
            newCharacter.Attributes.Strength.CloseCombat = randoIntAttribute();

            newCharacter.Attributes.Empathy.Value = randoIntAttribute();
            newCharacter.Attributes.Empathy.Manipulation = randoIntAttribute();
            newCharacter.Attributes.Empathy.MedicalAid = randoIntAttribute();
            newCharacter.Attributes.Empathy.Command = randoIntAttribute();

            return newCharacter;
        }
        private int randoIntAttribute()
        {
            return RandomGen.Next(4);
        }


        private List<Gear> GetRandomGear()
        {
            return GearResources.Generic;
        }
        private List<Weapon> GetRandomWeapons()
        {
            return new List<Weapon>()
            {
                WeaonFactory.CreateAssaultRifle(),
            };
        }

        private Talent GetRandomGenericTalent()
        {
            return Talents.Generic[RandomGen.Next(Talents.Generic.Count - 1)];
        }

        private Armor GetRandomArmor()
        {
            int rando = RandomGen.Next(10);
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
            return (new Armors()).ArmorTypes[rando];
        }

        private (string, string) GetNameUndGeschlecht()
        {
            string name;
            string geschlecht;
            List<string> nameList;

            if (RandomGen.Next(3) < 2)
            {
                nameList = Names.Male;
                geschlecht = "Männlich";
            }
            else
            {
                nameList = Names.Female;
                geschlecht = "Weiblich";
            }
            name = nameList[RandomGen.Next(nameList.Count - 1)];
            nameList.Remove(name);

            return (name, geschlecht);
        }

        public void ReadObjectProperties(object character, Dictionary<string, string> result)
        {
            foreach (var prop in character.GetType().GetProperties())
            {
                string sheetName = string.Empty;
                (int, int) minMax = (int.MinValue, int.MaxValue);

                foreach (System.Attribute attr in prop.GetCustomAttributes(true))
                {
                    if (attr is ComplexDataAttribute)
                    {
                        ReadObjectProperties(prop.GetValue(character), result);
                    }
                    if (attr is SheetnameAttribute)
                    {
                        sheetName = ((SheetnameAttribute)attr).Sheetname;
                    }

                    if (attr is MinMaxAttribute)
                    {
                        var tmp = (MinMaxAttribute)attr;
                        minMax = (tmp.Min, tmp.Max);
                    }

                    if (attr is CountableAttribute)
                    {
                        var tmp = (CountableAttribute)attr;
                        /*var liste = prop.GetValue(character) as List<object>;
                        var tmp = (CountableAttribute)attr;
                        
                        foreach (WaitForChangedResult akt2 in liste)
                        {
                            int i = 0;    
                        }*/
                    }
                }

                if (string.IsNullOrEmpty(sheetName)) continue;

                var wert = prop.GetValue(character);
                if (wert is int)
                {
                    int wertAsInt = (int)wert;
                    if (wertAsInt < minMax.Item1)
                    {
                        wertAsInt = minMax.Item1;
                    }
                    if (wertAsInt > minMax.Item2)
                    {
                        wertAsInt = minMax.Item2;
                    }
                    wert = wertAsInt;
                }
                result.Add(sheetName, wert is null ? "" : wert.ToString());


            }

        }
        public void FillCharakterSheet(Character character)
        {

        }
    }
}
