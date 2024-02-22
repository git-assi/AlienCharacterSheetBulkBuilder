using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Gear
    {
        [CountableAttribute(Min = 0, Max = 10)]
        [SheetnameAttribute(Sheetname = "Gear[n]")]
        public string Name { get; set; } = string.Empty;
    }
}
