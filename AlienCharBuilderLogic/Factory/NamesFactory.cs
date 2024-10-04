using AlienCharBuilderLogic.InGameResources;

namespace AlienCharBuilderLogic.Factory
{
    internal class NamesFactory
    {
        private static readonly Random RandomGen = new();

        private Names _names = new Names();
        private Names AllNames
        {
            get
            {
                if (!_names.Initialized)
                {
                    LoadNames();
                }
                return _names;
            }
        }

        private void LoadNames()
        {
            string pfad = $"{AppDomain.CurrentDomain.BaseDirectory}\\GameResources\\JSON\\Names.json";
            _names = JSONConverter.ReadJsonFromFile<Names>(pfad);
            _names.Initialized = true;
        }



        public (string, string, string) GetNameGenderAndPicture()
        {
            string name;
            string gender;
            string profilePicture = @$"{AppDomain.CurrentDomain.BaseDirectory}\GameResources\Images\Female\1.jpg";

            List<string> nameList;
            if (RandomGen.Next(3) < 2)
            {
                nameList = AllNames.Male;
                gender = "Männlich";
            }
            else
            {
                nameList = AllNames.Female;
                gender = "Weiblich";
            }
            name = nameList[RandomGen.Next(nameList.Count - 1)];
            nameList.Remove(name);

            return (name, gender, profilePicture);
        }
    }
}
