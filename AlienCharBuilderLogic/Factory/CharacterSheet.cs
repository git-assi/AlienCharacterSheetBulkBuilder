using AlienCharBuilderLogic.InGameResources;
using AlienCharBuilderLogic.Models;
using AlienCharBuilderLogic.PropertyAttributes;
using System.Diagnostics;


namespace AlienCharBuilderLogic.Factory
{
    public class CharacterFactory
    {
        private static readonly Random RandomGen = new();

        public Dictionary<string, string> ExtraInfo { get; set; } = new Dictionary<string, string>();
        public string GetExtraInfo()
        {
            return string.Join(", ", ExtraInfo.Select(pair => $"{pair.Key}: {pair.Value}"));
        }

        //StartAttribute in Summe 14
        //Hauptattribut (durch Klasse) darf max 5
        //Fertigkeiten 10 
        //Fertigkeiten +1 Hauptfertigkeiten +3 bei Start

        public Character CreateCharacter(string career)
        {
            return CreateCharacter(career, string.Empty);
        }

        public Character CreateCharacter(string career, string rankOverwrite)
        {
            var newCharacter = new Character()
            {
                Career = CareerResources.GetCareer(career),
                Conditions = new Conditions(),
                Talent = GetRandomGenericTalent(),
                TinyItems = new TinyItems(),
            };

            newCharacter.Rank = rankOverwrite != string.Empty ? rankOverwrite: newCharacter.Career.Baserank;

            (string name, string gender, byte[] profilePic) = GetNameAndGender();
            newCharacter.Appearance = GetExtraInfo();
            newCharacter.Name = name;
            newCharacter.Geschlecht = gender;

            newCharacter.Attributes.Wits.Value = randoIntAttribute(true);
            newCharacter.Attributes.Wits.Survival = randoIntSkill(true);
            newCharacter.Attributes.Wits.Comtech = randoIntSkill(true);
            newCharacter.Attributes.Wits.Observation = randoIntSkill(false);

            newCharacter.Attributes.Agility.Value = randoIntDebugAttribute(true);
            newCharacter.Attributes.Agility.Piloting = randoIntSkill(false);
            newCharacter.Attributes.Agility.RangedCombat = randoIntDebugSkill(false);
            newCharacter.Attributes.Agility.Mobilty = randoIntSkill(false);
            Debug.WriteLine("");

            newCharacter.Attributes.Strength.Value = randoIntAttribute(false);
            newCharacter.Attributes.Strength.HeavyMachinery = randoIntSkill(false);
            newCharacter.Attributes.Strength.Stamina = randoIntSkill(false);
            newCharacter.Attributes.Strength.CloseCombat = randoIntSkill(false);

            newCharacter.Attributes.Empathy.Value = randoIntAttribute(false);
            newCharacter.Attributes.Empathy.Manipulation = randoIntSkill(false);
            newCharacter.Attributes.Empathy.MedicalAid = randoIntSkill(false);
            newCharacter.Attributes.Empathy.Command = randoIntSkill(false);

            int maxSumAttributes = 14;
            int maxSumSkills = 10;

            Factory.AttributeFactory.SetCareerAttributeValues(newCharacter);

            newCharacter.Weapons.AddRange(newCharacter.Career.DefaultWeapons);

            newCharacter.Armor = GetRandomArmor();
            newCharacter.Talent = GetRandomGenericTalent();
            newCharacter.Gear = GetRandomGear();

            newCharacter.TinyItems.AddItem("Foto");
            newCharacter.TinyItems.AddItem("Zigarette");
            newCharacter.TinyItems.AddItem("Zigarette");
            newCharacter.TinyItems.AddItem("Zigarette");
            newCharacter.TinyItems.AddItem("Zigarette");

            newCharacter.Conditions.Encumbrance = ReadObjectWeight(newCharacter).ToString("F2");

            return newCharacter;
        }
        private int randoIntAttribute(bool isMainAttribute)
        {
            int max = isMainAttribute ? 5 : 4;
            int min = isMainAttribute ? 3 : 2;
            return RandomGen.Next(min, max);
        }

        private int randoIntDebugAttribute(bool isMainAttribute)
        {
            int max = isMainAttribute ? 5 : 4;
            int min = isMainAttribute ? 3 : 2;
            int result = RandomGen.Next(min, max);
            Debug.Write($"Attribute {result} ");
            return result;
        }

        private int randoIntSkill(bool isMainSkill)
        {
            int max = isMainSkill ? 1 : 3;
            int skill = 2;
            while (skill == 2) { skill = RandomGen.Next(0, max); }
            return skill;
        }

        private int randoIntDebugSkill(bool isMainSkill)
        {
            int max = isMainSkill ? 1 : 3;
            int skill = 2;
            while (skill == 2) { skill = RandomGen.Next(0, max); }            
            Debug.Write($"Skill {skill} ");          
            return skill;
        }


        private List<Gear> GetRandomGear()
        {
            return GearResources.Generic;
        }


        private Talent GetRandomGenericTalent()
        {
            return new Talent() { Category = Constants.Talent.GENERAL, Description = "Platzhalter", Name = "RandomGenericTalent" };
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

        private static Names _names = new Names();
        private static Names AllNames 
        { 
            get
            {
                if (!_names.Initialized)
                {
                    LoadNames();
                }
                return _names;
            }
        }

        private static void LoadNames()
        {
            string pfad = $"{AppDomain.CurrentDomain.BaseDirectory}\\GameResources\\JSON\\Names.json";
            _names = JSONConverter.ReadJsonFromFile<Names>(pfad);
            _names.Initialized = true;
        }

        private (string, string, byte[]) GetNameAndGender()
        {
            string name;
            string gender;
            byte[] profilePicture;

            List<string> nameList;
            if (RandomGen.Next(3) < 2)
            {
                nameList = _names.Male;
                gender = "Männlich";
            }
            else
            {
                nameList = _names.Female;
                gender = "Weiblich";
            }
            name = nameList[RandomGen.Next(nameList.Count - 1)];
            nameList.Remove(name);

            return (name, gender, profilePicture);
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
                        if (prop.GetValue(dataObject) != null)
                        {
                            result += (double)prop.GetValue(dataObject);
                        }
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
                        var data = prop.GetValue(dataObject);
                        if (data != null)
                        {
                            ReadObjectProperties(data, result, level);
                        }
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
     
    }
}