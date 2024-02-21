using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Gear
    {
        [SheetnameAttribute(Sheetname = "Gear[n]")]
        public string Name { get; set; } = string.Empty;
    }
}
