using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Armor
    {
        [SheetnameAttribute(Sheetname = Constants.ARMOR)]
        public string Name { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = Constants.ARMOR_RATING)]
        public int Rating { get; set; }
    }
}
