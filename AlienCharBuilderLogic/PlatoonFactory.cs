using AlienCharBuilderLogic.Factory;
using AlienCharBuilderLogic.Models;
using iText.Forms.Fields;
using iText.Forms;
using iText.Kernel.Pdf;


namespace AlienCharBuilderLogic
{
    public class PlatoonFactory
    {
        public Platoon CreatePlatoon()
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
                Name = "285 Light Infantry",
                Lieutenant = new NPC(),
                SecondInCommand = new NPC(),

                SectionA = new Section()
                {
                    APC = GroundVehicleFactory.AllGroundVehicles[Constants.GroundVehicle.TYPE.M577_APC],
                    VehicleDriver = characterFactory.CreateCharacter(Constants.Career.DRIVER),

                    Dropship = AirVehiclesFactory.AllAirVehicles[Constants.AirVehicles.TYPE.CHEYENNE],
                    Wing = new FlightCrew()
                    {
                        Pilot = characterFactory.CreateCharacter(Constants.Career.PILOT),
                        WeaponOfficer = characterFactory.CreateCharacter(Constants.Career.WEAPONS_OFFICER),
                    },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.SERGANT),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE)
                        },
                        SecondTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.HEAVY_GUNNER)
                        }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE, Constants.Rank.PRIVATE_FC),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE)
                        },
                        SecondTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.MEDIC)
                        }
                    }
                },

                SectionB = new Section()
                {
                    APC = GroundVehicleFactory.AllGroundVehicles[Constants.GroundVehicle.TYPE.M577_APC],
                    VehicleDriver = characterFactory.CreateCharacter(Constants.Career.DRIVER),

                    Dropship = AirVehiclesFactory.AllAirVehicles[Constants.AirVehicles.TYPE.BLACKFLY],
                    Wing = new FlightCrew()
                    {
                        Pilot = characterFactory.CreateCharacter(Constants.Career.PILOT),
                        WeaponOfficer = characterFactory.CreateCharacter(Constants.Career.WEAPONS_OFFICER),
                    },

                    FirstSquad = new Squad()
                    {
                        FirstTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE, Constants.Rank.CORPORAL),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE)
                        },
                        SecondTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.HEAVY_GUNNER)
                        }
                    },

                    SecondSquad = new Squad()
                    {
                        FirstTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.MARINE)
                        },
                        SecondTeam = new Team()
                        {
                            Marine1 = characterFactory.CreateCharacter(Constants.Career.MARINE),
                            Marine2 = characterFactory.CreateCharacter(Constants.Career.TECH)
                        }
                    }
                },
            };

            return plt;

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

        private string PFAD(string name)
        {
             return @$".\GameResources\JSON\Platoon_{name.Replace(" ", "_")}.json"; 
        }

        public Platoon LoadPlatoon(string name)
        {
            var x = InGameResources.JSONConverter.ReadJsonFromFile<Platoon>(PFAD(name));
            return x;
        }

        public void SavePlatoon(Platoon platoon)
        {
            InGameResources.JSONConverter.WriteObjectToJsonFile(PFAD(platoon.Name), platoon);
        }
    }


}