namespace AlienCharBuilderLogic.Models
{
    public class Attribute
    {
        public string Name { get; set; } = string.Empty;
        public string Sheetname { get; set; } = string.Empty;
        public int Value { get; set; }
    }

    public class AttributeInit
    {
        public static List<Attribute> GetAttributes()
        {
            var result = new List<Attribute>()
            {
                new Attribute()
                                    {
                                        Sheetname = "Str",
                                        Name = "Strength",
                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Ag",
                                                        Name = "Agility",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Wits",
                                                        Name = "Wits",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Emp",
                                                        Name = "Empathy",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "HM",
                                                        Name = "HeavyMachinery",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "CC",
                                                        Name = "CloseCombat",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "St",
                                                        Name = "Stamina",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "O",
                                                        Name = "Observation",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Su",
                                                        Name = "Survival",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Com",
                                                        Name = "Comtech",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "MA",
                                                        Name = "MedicalAid",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Man",
                                                        Name = "Manipulation",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Cmd",
                                                        Name = "Command",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "P",
                                                        Name = "Piloting",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Mo",
                                                        Name = "Mobilty",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "RC",
                                                        Name = "RangedCombat",
                                                    },
                new Attribute()
                                                    {
                                                        Sheetname = "Enc",
                                                        Name = "Encumbrance",
                                                    },
            };

            return result;
        }
    }
}
