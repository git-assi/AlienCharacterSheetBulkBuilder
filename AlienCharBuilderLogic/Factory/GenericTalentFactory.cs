using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    internal class GenericTalentFactory
    {
        private List<Talent> _readAllgemeineTalenteFromFile = new List<Talent>();

        private static readonly Random RandomGen = new();
        

        public Talent GetRandomGenericTalent()
        {
            if (_readAllgemeineTalenteFromFile.Count == 0)
            {
                _readAllgemeineTalenteFromFile = ReadAllgemeineTalenteFromFile();
            }
            int max = _readAllgemeineTalenteFromFile.Count - 1;
            int min = 0;
            int rando = RandomGen.Next(min, max);            

            Talent talent = _readAllgemeineTalenteFromFile[rando];
            _readAllgemeineTalenteFromFile.RemoveAt(rando);
            return talent;  
        }

        public List<Talent> ReadAllgemeineTalenteFromFile()
        {
            var listT = new List<Talent>();
            string rawdata = File.ReadAllText(@".\GameResources\Dump\AllgemeineTalente.txt");
            var rawdataSplit = rawdata.Replace(Environment.NewLine, " ").Split("#", StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in rawdataSplit)
            {
                var xSplit = x.Split(": ");
                listT.Add(new Talent() { Category = "Allgemein", Name = xSplit[0].Trim(), Description = xSplit[1].Trim() });
            }

            rawdata = File.ReadAllText(@".\GameResources\Dump\CareerTalents.txt");
            rawdataSplit = rawdata.Replace(Environment.NewLine, " ").Split("#", StringSplitOptions.RemoveEmptyEntries);
            foreach (var x in rawdataSplit)
            {
                var xSplit = x.Split(": ");
                listT.Add(new Talent() { Category = xSplit[0].Trim(), Name = xSplit[1].Trim(), Description = xSplit[2].Trim() });
            }

            return listT;

        }

        private const string PFAD = @$".\GameResources\JSON\Talente.json";
        public List<Talent> LoadTalentResources()
        {
            var x = InGameResources.JSONConverter.ReadJsonFromFile<List<Talent>>(PFAD);
            return x;
        }

        public void SaveWeaponResources(List<Talent> talents)
        {
            InGameResources.JSONConverter.WriteObjectToJsonFile(PFAD, talents);
        }
    }
}
