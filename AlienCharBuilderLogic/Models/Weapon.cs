using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class WeaponFactory
    {
    
        public static Weapon CreateAssaultRifle()
        {
            return new Weapon()
            {
                Name = "Armat M41A Impulsgewehr",
                Bonus = "+1",
                Damage = 2,
                Range = Constans.REICHWEITE.WEIT,
                Weight = 1,
                Special = "Panzerbrechend",
            };
        }

        public static Weapon CreatePumpgun()
        {
            return new Weapon()
            {
                Name = "Armat M37A2 Pumpgun Kaliber 12",
                Bonus = "+2",
                Damage = 3,
                Range = Constans.REICHWEITE.KURZ,
                Weight = 1,
                Special = "Doppelte Panzerung",
            };
        }

        public static Weapon CreateRevolver()
        {
            return new Weapon()
            {
                Name = "Revolver .357 Magnum",
                Bonus = "+1",
                Damage = 2,
                Range = Constans.REICHWEITE.MITTEL,
                Weight = 1,
            };
        }
       
        public static Weapon CreateSmartgun()
        {
            return new Weapon()
            {
                Name = "M56A2 „Smartgun“",
                Bonus = "+3",
                Damage = 3,
                Range = Constans.REICHWEITE.WEIT,
                Weight = 3,
                Special = "Panzerbrechend",
            };
        }

        public static Weapon CreatePistol()
        {
            return new Weapon()
            {
                Name = "Armat M4A3 Dienstpistole",
                Bonus = "+2",
                Damage = 1,
                Range = Constans.REICHWEITE.MITTEL,
                Weight = 0.5,
            };
        }
    }

    public class Constans
    {
        public class REICHWEITE
        {
            public const string KURZ = "kurz";
            public const string WEIT = "weit";
            public const string MITTEL = "mittel";
        }
    }

    public class Weapon
    {
        [SheetnameAttribute(Sheetname = "Weapon[n]")]
        public string Name { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = "WB[n]")]
        public string Bonus { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = "Dam[n]")]
        public int Damage { get; set; }
        [SheetnameAttribute(Sheetname = "R[n]")]
        public string Range { get; set; } = string.Empty;
        [WeightAttribute()]
        public double Weight { get; set; } = 0;
        public string Special { get; set; } = string.Empty;
    }
}
