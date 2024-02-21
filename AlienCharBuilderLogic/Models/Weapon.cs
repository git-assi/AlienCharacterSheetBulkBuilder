using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
   
    public class Weapon
    {
        [SheetnameAttribute(Sheetname = "Weapon[n]")]
        public string Name { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = "WB[n]")]
        public int Bonus { get; set; }
        [SheetnameAttribute(Sheetname = "Dam[n]")]
        public int Damage { get; set; }
        [SheetnameAttribute(Sheetname = "R[n]")]
        public int Range { get; set; }
    }
}
