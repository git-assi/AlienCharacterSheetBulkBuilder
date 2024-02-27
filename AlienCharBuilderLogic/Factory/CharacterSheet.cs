using AlienCharBuilderLogic.InGameResources;
using AlienCharBuilderLogic.Models;
using AlienCharBuilderLogic.PropertyAttributes;
using System.Collections.Generic;


namespace AlienCharBuilderLogic.Factory
{
    internal class CharacterFactory
    {
        private static readonly Random RandomGen = new();

        public Dictionary<string, string> ExtraInfo { get; set; } = new Dictionary<string, string>();
        public string GetExtraInfo()
        {
            return string.Join(", ", ExtraInfo.Select(pair => $"{pair.Key}: {pair.Value}"));
        }

        public Character CreateCharacter(string career)
        {
            var newCharacter = new Character();
            (string name, string geschlecht) = GetNameUndGeschlecht();
            newCharacter.Appearance = GetExtraInfo();
            newCharacter.Name = name + $"({geschlecht})";
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

            newCharacter.Conditions.Encumbrance = ReadObjectWeight(newCharacter).ToString("F2");

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
            var result = new List<Weapon>();

            int rando = randoIntAttribute();

            if (rando == 1)
            {
                result.Add(WeaonFactory.CreateAssaultRifle());
            }
            if (rando == 2)
            {
                result.Add(WeaonFactory.CreatePistol());
            }
            if (rando == 3)
            {
                result.Add(WeaonFactory.CreateSmartgun());
            }

            return result;
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

        public double ReadObjectWeight(object dataObject)
        {
            double result = 0;
            foreach (var prop in dataObject.GetType().GetProperties())
            {
                foreach (System.Attribute attr in prop.GetCustomAttributes(true))
                {
                    if (attr is WeightAttribute)
                    {
                        result += (double)prop.GetValue(dataObject);
                        break;
                    }
                    if (attr is ComplexDataAttribute)
                    {
                        result += ReadObjectWeight(prop.GetValue(dataObject));
                    }
                    if (attr is CountableAttribute)
                    {
                        if (prop.GetValue(dataObject) is IEnumerable<object> enumerable)
                        {
                            var tmp = (CountableAttribute)attr;
                            var minMax = (tmp.Min, tmp.Max);
                            int i = 0;
                            foreach (var item in enumerable)
                            {
                                i++;
                                if (i > minMax.Item2)
                                {
                                    break;
                                }
                                result += ReadObjectWeight(item);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public void ReadObjectProperties(object dataObject, Dictionary<string, string> result, int level)
        {
            foreach (var prop in dataObject.GetType().GetProperties())
            {
                string sheetName = string.Empty;
                (int, int) minMax = (int.MinValue, int.MaxValue);

                foreach (System.Attribute attr in prop.GetCustomAttributes(true))
                {
                    if (attr is ComplexDataAttribute)
                    {
                        ReadObjectProperties(prop.GetValue(dataObject), result, level);
                    }
                    if (attr is SheetnameAttribute)
                    {
                        sheetName = ((SheetnameAttribute)attr).Sheetname.Replace("[n]", level.ToString());
                    }
                    if (attr is MinMaxAttribute)
                    {
                        var tmp = (MinMaxAttribute)attr;
                        minMax = (tmp.Min, tmp.Max);
                    }
                    if (attr is CountableAttribute)
                    {
                        var tmp = (CountableAttribute)attr;
                        minMax = (tmp.Min, tmp.Max);
                        if (prop.GetValue(dataObject) is IEnumerable<object> enumerable)
                        {
                            int i = minMax.Item1;
                            foreach (var item in enumerable)
                            {
                                i++;
                                if (i > minMax.Item2)
                                {
                                    break;
                                }
                                ReadObjectProperties(item, result, i);
                            }
                        }
                    }
                }

                if (string.IsNullOrEmpty(sheetName)) continue;

                var wert = prop.GetValue(dataObject);
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
