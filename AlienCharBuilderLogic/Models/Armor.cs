using AlienCharBuilderLogic.PropertyAttributes;
namespace AlienCharBuilderLogic.Models
{
    public class Armor
    {
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.ARMOR)]
        public string Name { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.ARMOR_RATING)]
        [MinMaxAttribute(Max = 5, Min = 0)]
        public int Rating { get; set; }
    }
}
