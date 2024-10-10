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
    public class foobar()
    {
        public void dfg()
        {
            var x = new List<Talent>() {
                
            };
            
        }

        public void sfd()
        {
            var listT = new List<Talent>();
            string rawdata = File.ReadAllText(@".\GameResources\Dump\AllgemeineTalente.txt");
            var rawdataSplit = rawdata.Replace(Environment.NewLine, " ").Split("#", StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in rawdataSplit)
            {
                var xSplit = x.Split(": ");
                listT.Add(new Talent() { Category = "Allgemein", Name = xSplit[0].Trim(), Description = xSplit[1].Trim() });
            }
            int i = 0;
        }
    }
}
