using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Career
    {

        [SheetnameAttribute(Sheetname = Constants.PropertyAttributes.CAREER)]
        public string Name { get; set; } = string.Empty;

        public string Baserank { get; set; } = string.Empty;

        public List<Weapon> DefaultWeapons { get; set; } = new List<Weapon>();

        
    }
}
