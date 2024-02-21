namespace AlienCharBuilderLogic.PropertyAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class SheetnameAttribute : Attribute
    {
        public string Sheetname { get; set; } = string.Empty;
    }
}
