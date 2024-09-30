using AlienCharBuilderLogic.Factory;
using AlienCharBuilderLogic.Models;
using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;


namespace AlienCharBuilderLogic
{
    public class PlatoonFactory
    {
        public static void CreatePlatoon()
        {

            var characterFactory = new CharacterFactory();
            

            /*
            var data = new Dictionary<string, string>();
            var foobar = fac.CreateCharacter(Constants.Career.HEAVY_GUNNER);            
            fac.ReadObjectProperties(foobar, data, 0);

            /*var path = WriteDataInPDF(data);
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });/**/
          
            var plt = new Platoon()
            {
                Lieutenant = new NPC(),
                SecondInCommand = new NPC(),

                SectionA = new Section()
                {
                    APC = new GroundVehicle(),
                    VehicleDriver = characterFactory.CreateCharacter(Constants.Career.DRIVER),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = characterFactory.CreateCharacter(Constants.Career.PILOT), WeaponOfficer = characterFactory.CreateCharacter(Constants.Career.WEAPONS_OFFICER), },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE, Constants.Rank.SERGANT), Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE), Marine2 = characterFactory.CreateCharacter(Constants.Career.HEAVY_GUNNER) }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE, Constants.Rank.PRIVATE_FC), Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE), Marine2 = characterFactory.CreateCharacter(Constants.Career.MEDIC) }
                    }
                },

                SectionB = new Section()
                {
                    APC = new GroundVehicle(),
                    VehicleDriver = characterFactory.CreateCharacter(Constants.Career.DRIVER),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = characterFactory.CreateCharacter(Constants.Career.PILOT), WeaponOfficer = characterFactory.CreateCharacter(Constants.Career.WEAPONS_OFFICER), },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE, Constants.Rank.CORPORAL), Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE), Marine2 = characterFactory.CreateCharacter(Constants.Career.HEAVY_GUNNER) }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE), Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE), Marine2 = characterFactory.CreateCharacter(Constants.Career.TECH) }
                    }
                },
            };



            /*var data = new Dictionary<string, string>();
            fac.ReadObjectProperties(newChar, data);
            */
            int xx = 1;
        }

        public static string WriteDataInPDF(Dictionary<string, string> data)
        {

            string src = @$"{AppDomain.CurrentDomain.BaseDirectory}alienFFCharSheet.pdf";
            string dest = @$"{AppDomain.CurrentDomain.BaseDirectory}{data["Name"]}.pdf";

            try
            {
                PdfDocument pdf = new PdfDocument(new PdfReader(src), new PdfWriter(dest));
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
                IDictionary<string, PdfFormField> fields = form.GetAllFormFields();

                data["Stress1"] = "Yes";
                data["Freezing"] = "Yes";

                foreach (var field in fields)
                {                    
                    if (data.ContainsKey(field.Key))
                    {                       
                        fields[field.Key].SetValue(data[field.Key]);                    
                    }                    
                }

                pdf.Close();                             

            }
            catch (Exception ex)
            {

                throw;
            }
            
            
            return dest;
        }
    }


}