using iTextSharp.text.pdf;
using System.Data;

namespace AlienCharBuilderLogic
{
    public class Class1
    {
        public void narf()
        {
            
        }

        public void narf2()
        {
            string baseString = @"new Attribute()
                                    {
	                                    Sheetname = ""[SN]"",
                                        Name = ""[N]"",
                                    },";

            var attr = new List<(string, string)>();
            attr.Add(("Str", "Strength"));
            attr.Add(("Ag", "Agility"));
            attr.Add(("Wits", "Wits"));
            attr.Add(("Emp", "Empathy"));
            attr.Add(("HM", "HeavyMachinery"));
            attr.Add(("CC", "CloseCombat"));
            attr.Add(("St", "Stamina"));
            attr.Add(("O", "Observation"));
            attr.Add(("Su", "Survival"));
            attr.Add(("Com", "Comtech"));
            attr.Add(("MA", "MedicalAid"));
            attr.Add(("Man", "Manipulation"));
            attr.Add(("Cmd", "Command"));
            attr.Add(("P", "Piloting"));
            attr.Add(("Mo", "Mobilty"));
            attr.Add(("RC", "RangedCombat"));
            attr.Add(("Enc", "Encumbrance"));
            string foobar = "";
            foreach(var at in attr)
            {
                foobar += baseString.Replace("[SN]", at.Item1).Replace("[N]", at.Item2) + Environment.NewLine;
            }

        }
        public void Class()
        {
            try
            {
                string klasse = "";
                using (FileStream outFile = new FileStream("result.pdf", FileMode.Create))
                {
                    PdfReader pdfReader = new PdfReader("alienFFCharSheet.pdf");
                    PdfStamper pdfStamper = new PdfStamper(pdfReader, outFile);
                    AcroFields fields = pdfStamper.AcroFields;
                    //rest of the code here
                    //fields.SetField("n°1", "value");
                    //...

                    foreach (var field in fields.Fields)
                    {
                        fields.SetField(field.Key, field.Key);
                        klasse += "public string " + (field.Key).Replace(" ", "_") + " { get; set; }" + Environment.NewLine;
                    }

                    pdfStamper.Close();
                    pdfReader.Close();
                }
                System.IO.File.WriteAllText("char.cs", klasse);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class IgnoreAttribute : Attribute
        {
            public bool OrmIgnore { get; set; }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class DecryptAttribute : Attribute
        {
            public bool Decrypt { get; set; }
        }

        public class Inspector
        {
            public string Benutzername { get; set; } = string.Empty;
            [DecryptAttribute(Decrypt = true)]
            public string Pin { get; set; } = string.Empty;


            [IgnoreAttribute(OrmIgnore = true)]
            public bool SiehtDatePicker { get; internal set; }


        }
        //var inspector = ReadObject<Inspector>(inspectorData);
        public static T ReadObject<T>(DataTable inspectorData) where T : new()
        {
            if (inspectorData.Rows.Count == 0)
            {
                throw new Exception("keine Daten gefunden");
            }

            DataRow row = inspectorData.Rows[0];

            T obj = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                try
                {
                    if (!prop.CanWrite)
                    {
                        continue;
                    }

                    bool decrypt = false;
                    bool ormIgnore = false;

                    foreach (Attribute attr in prop.GetCustomAttributes(true))
                    {
                        if (attr is IgnoreAttribute)
                        {
                            ormIgnore = ((IgnoreAttribute)attr).OrmIgnore;
                        }

                        if (attr is DecryptAttribute)
                        {
                            decrypt = ((DecryptAttribute)attr).Decrypt;
                        }
                    }

                    if (ormIgnore) continue;

                    string value = row[prop.Name].ToString();
                    if (decrypt && !string.IsNullOrWhiteSpace(value)) value = "Decrypt(value)";
                    prop.SetValue(obj, value);
                }
                catch (Exception ex)
                {
                    ex.Data.Add("Schlüssel", prop.PropertyType.Name);
                    throw;
                }

            }
            return obj;
        }
    }
}