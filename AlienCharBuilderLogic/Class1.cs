using AlienCharBuilderLogic.Factory;
using AlienCharBuilderLogic.Models;
using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;
using System.Data;
using System.Diagnostics;


namespace AlienCharBuilderLogic
{
    public class Class1
    {
        public static void Narf()
        {

            var fac = new CharacterFactory();
            

            /*
            var data = new Dictionary<string, string>();
            var foobar = fac.CreateCharacter(Constants.Career.HEAVY_GUNNER);            
            fac.ReadObjectProperties(foobar, data, 0);

            var path = WriteDataInPDF(data);
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
                    VehicleDriver = fac.CreateCharacter(Constants.Career.DRIVER),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = fac.CreateCharacter(Constants.Career.PILOT), WeaponOfficer = fac.CreateCharacter(Constants.Career.WEAPONS_OFFICER), },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE, Constants.Rank.SERGANT), Marine2 = fac.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.HEAVY_GUNNER) }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE, Constants.Rank.PRIVATE_FC), Marine2 = fac.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.MEDIC) }
                    }
                },

                SectionB = new Section()
                {
                    APC = new GroundVehicle(),
                    VehicleDriver = fac.CreateCharacter(Constants.Career.DRIVER),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = fac.CreateCharacter(Constants.Career.PILOT), WeaponOfficer = fac.CreateCharacter(Constants.Career.WEAPONS_OFFICER), },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE, Constants.Rank.CORPORAL), Marine2 = fac.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.HEAVY_GUNNER) }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.TECH) }
                    }
                },
            };



            /*var data = new Dictionary<string, string>();
            fac.ReadObjectProperties(newChar, data);
            */
            int xx = 1;
        }

        private static string WriteDataInPDF(Dictionary<string, string> data)
        {
            string src = "alienFFCharSheet.pdf";
            string dest = $"{data["Name"]}.pdf";

            PdfDocument pdf = new PdfDocument(new PdfReader(src), new PdfWriter(dest));
            PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
            IDictionary<string, PdfFormField> fields = form.GetAllFormFields();

            foreach (var field in fields)
            {
                data["Stress1"] = "Yes";
                data["Freezing"] = "Yes";

                if (data.ContainsKey(field.Key))
                {
                    PdfFormField toSet;
                    fields.TryGetValue("name", out toSet);
                    toSet.SetValue("Abhishek Kumar");
                }


                pdf.Close();
            }
            return dest;
        }
    }


}