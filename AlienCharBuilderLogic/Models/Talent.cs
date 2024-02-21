using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Talent
    {
        [SheetnameAttribute(Sheetname = Constants.TALENT_1)]
        public string Name { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = Constants.CONVENTION_TALENT_DESCRIPTION)]
        public string Description { get; set; } = string.Empty;
    }
}
