using AlienCharBuilderLogic.Factory;
using AlienCharBuilderLogic.Models;
using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using System.Data;
using System.Diagnostics;


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
            string src = "alienFFCharSheet.pdf";
            string dest = $"{data["Name"]}.pdf";

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
                        PdfFormField toSet;
                        if (fields.TryGetValue(field.Key, out toSet))
                        {
                            var value = data[field.Key];
                            try
                            {
                                toSet?.SetValue(value);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Exception " + field.Key);
                            }                            
                        }
                        else
                        {
                            Console.WriteLine("Fail " + field.Key);
                        }
                    }


                    pdf.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
            
            return dest;
        }
    }


}