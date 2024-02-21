namespace AlienCharBuilderLogic.Models
{
    public class Talent
    {
        [SheetnameAttribute(Sheetname = "Talent 1")]
        public string Name { get; set; } = string.Empty;
        [SheetnameAttribute(Sheetname = "Convention talent description")]
        public string Description { get; set; } = string.Empty;
    }
}
