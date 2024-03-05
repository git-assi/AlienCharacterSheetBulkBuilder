using AlienCharBuilderLogic;
using AlienCharBuilderLogic.InGameResources;
using AlienCharBuilderLogic.Models;
using System.Windows;

namespace TestUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Class1.Narf();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                JSONConverter.WriteObjectToJsonFile<List<string>>("Planet_Names.json", Names.Planet_Names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_xml_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            string pfad = @".\InGameResources\Dump\AllgemeineTalente.txt";
            List<string> talents = System.IO.File.ReadAllText(pfad).Replace(Environment.NewLine, " ").Replace("  ", " ").Trim().Split("#").ToList();
            var generalTalents = new List<Talent>();

            foreach(var aktTalent in talents)
            {
                var aktSPlit = aktTalent.Split(":");
                generalTalents.Add(new Talent()
                {
                    Category = AlienCharBuilderLogic.Constants.Talent.GENERAL,
                    Description = aktSPlit[1].Trim(),
                    Name = aktSPlit[0].Trim().Substring(0,1) + aktSPlit[0].Trim().Substring(1).ToLower().Trim(),
                }) ;
            }

             pfad = "C:\\Temp\\Ergebnis.json";
            JSONConverter.WriteObjectToJsonFile(pfad, generalTalents);

        }
    }
}