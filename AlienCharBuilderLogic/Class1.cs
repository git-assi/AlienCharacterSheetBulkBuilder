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
                    VehicleDriver = fac.CreateCharacter(Career.Constants.DRIVER),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = fac.CreateCharacter(Career.Constants.PILOT), WeaponOfficer = fac.CreateCharacter(Career.Constants.WEAPONS_OFFICER), },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.HEAVY_GUNNER) }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.MEDIC) }
                    }
                },

                SectionB = new Section()
                {
                    APC = new GroundVehicle(),
                    VehicleDriver = fac.CreateCharacter(Career.Constants.DRIVER),

                    Dropship = new AirVehicle() { Name = "Blackfly" },
                    Wing = new FlightCrew() { Pilot = fac.CreateCharacter(Career.Constants.PILOT), WeaponOfficer = fac.CreateCharacter(Career.Constants.WEAPONS_OFFICER), },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.HEAVY_GUNNER) }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.MARINE) },
                        SecondTeam = new Team() { Marine1 = fac.CreateCharacter(Career.Constants.MARINE), Marine2 = fac.CreateCharacter(Career.Constants.TECH) }
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