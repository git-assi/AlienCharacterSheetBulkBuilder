using AlienCharBuilderLogic.PropertyAttributes;

namespace AlienCharBuilderLogic.Models
{
    public class Consumables
    {
        [SheetnameAttribute(Sheetname = "Air")]
        public int Air { get; set; }
        [SheetnameAttribute(Sheetname = "Food")]
        public int Food { get; set; }
        [SheetnameAttribute(Sheetname = "Pow")]
        public int Power { get; set; }
        [SheetnameAttribute(Sheetname = "Water")]
        public int Water { get; set; }
    }
}
