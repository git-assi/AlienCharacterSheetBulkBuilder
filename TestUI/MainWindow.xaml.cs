using AlienCharBuilderLogic;
using AlienCharBuilderLogic.InGameResources;
using AlienCharBuilderLogic.Models;
using PdfSharp.Pdf.IO;
using System.Diagnostics;
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
                PlatoonFactory.CreatePlatoon();
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

            foreach (var aktTalent in talents)
            {
                var aktSPlit = aktTalent.Split(":");
                generalTalents.Add(new Talent()
                {
                    Category = AlienCharBuilderLogic.Constants.Talent.GENERAL,
                    Description = aktSPlit[1].Trim(),
                    Name = aktSPlit[0].Trim().Substring(0, 1) + aktSPlit[0].Trim().Substring(1).ToLower().Trim(),
                });
            }

            pfad = "C:\\Temp\\AllgemeineTalente.json";
            JSONConverter.WriteObjectToJsonFile(pfad, generalTalents);

        }

        private void Button_json_Click(object sender, RoutedEventArgs e)
        {
            string pfad = $"{AppDomain.CurrentDomain.BaseDirectory}\\GameResources\\JSON\\AllgemeineTalente.json";
            var x = JSONConverter.ReadJsonFromFile<List<Talent>>(pfad);

            var y = x.Where(t => t.Category == AlienCharBuilderLogic.Constants.Career.PILOT);

            int xx = 1;
        }

        private void Button_Click_CreateSingleChar(object sender, RoutedEventArgs e)
        {
            try
            {
                var characterFactory = new AlienCharBuilderLogic.Factory.CharacterFactory();
                var character = characterFactory.CreateCharacter(AlienCharBuilderLogic.Constants.Career.MARINE);

                var data = new Dictionary<string, string>();
                characterFactory.ReadObjectProperties(character, data, 0);
                var fileWithPath = PlatoonFactory.WriteDataInPDF(data);

                // var document = PdfReader.Open(fileWithPath, PdfDocumentOpenMode.Modify);
                //PDFEditor.InsertPicture(document, character.ProfilePic);
                string profilePicture = @$"{AppDomain.CurrentDomain.BaseDirectory}GameResources\Images\Female\1.jpg";
                PDFEditor.InsertPicture(fileWithPath, profilePicture);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click_pdfTest(object sender, RoutedEventArgs e)
        {
            try
            {


                string fileWithPath = @$"{AppDomain.CurrentDomain.BaseDirectory}blanko22.pdf";
                string fileWithPath2 = @$"{AppDomain.CurrentDomain.BaseDirectory}blanko2.pdf";
                string profilePicture = @$"{AppDomain.CurrentDomain.BaseDirectory}GameResources\Images\Female\1.jpg";

                //PDFEditor.GeneratePDF(fileWithPath, profilePicture);
                //PDFEditor.InsertPicture(fileWithPath, profilePicture);
                PDFEditor.InsertPicture(fileWithPath, profilePicture);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}