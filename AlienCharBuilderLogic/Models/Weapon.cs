using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
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
        public List<string> Special { get; set; } = new List<string>() { string.Empty };
    }
}
