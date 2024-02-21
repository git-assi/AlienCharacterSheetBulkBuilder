namespace AlienCharBuilderLogic.Models
{
    public class TinyItem
    {
        [SheetnameAttribute(Sheetname = "Tiny items")]
        public List<string> Name { get; set; } = new List<string>();
    }
}
