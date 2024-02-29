using AlienCharBuilderLogic.Factory;
using AlienCharBuilderLogic.InGameResources.Models;
using AlienCharBuilderLogic.Models;
using iTextSharp.text.pdf;
using System.Data;
using System.Diagnostics;

namespace AlienCharBuilderLogic
{
    public class Class1
    {
        public static void Narf()
        {

            var fac = new CharacterFactory();


             /*var data = new Dictionary<string, string>();
             fac.ReadObjectProperties(fac.CreateCharacter("Marine"), data, 0);

             var path = WriteDataInPDF(data);
             Process.Start(new ProcessStartInfo
             {
                 FileName = path,
                 UseShellExecute = true
             });*/

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
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.HEAVY_GUNNER) }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.MARINE) },
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
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Constants.Career.MARINE), Marine2 = fac.CreateCharacter(Constants.Career.MARINE) },
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
            string path = $"{data["Name"]}.pdf";
            using (FileStream outFile = new FileStream(path, FileMode.Create))
            {
                PdfReader pdfReader = new PdfReader("alienFFCharSheet.pdf");
                PdfStamper pdfStamper = new PdfStamper(pdfReader, outFile);
                AcroFields fields = pdfStamper.AcroFields;

                foreach (var field in fields.Fields)
                {
                    data["Stress1"] = "Yes";
                    data["Freezing"] = "Yes";

                    if (data.ContainsKey(field.Key))
                    {
                        fields.SetField(field.Key, data[field.Key]);
                    }

                }

                pdfStamper.Close();
                pdfReader.Close();
            }
            return path;
        }
    }


}