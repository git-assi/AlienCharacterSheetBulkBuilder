using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Talent
    {
        public required string Category { get; set; }

        [Sheetname(Sheetname = Constants.PropertyAttributes.TALENT_1)]
        public string Name { get; set; } = string.Empty;
        [Sheetname(Sheetname = Constants.PropertyAttributes.CONVENTION_TALENT_DESCRIPTION)]
        public string Description { get; set; } = string.Empty;
    }
;
    
}
