using AlienCharBuilderLogic.Models;
using AlienCharBuilderLogic.PropertyAttributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AlienCharBuilderLogic.Class1;

namespace AlienCharBuilderLogic.Factory
{
    internal class CharacterSheet
    {
        public void ReadCharacter(object character, Dictionary<string, string> result)
        {
            foreach (var prop in character.GetType().GetProperties())
            {
                
                try
                {
                    string sheetName = string.Empty;
                    (int, int) minMax = (int.MinValue, int.MaxValue);

                    foreach (System.Attribute attr in prop.GetCustomAttributes(true))
                    {
                        if (attr is ComplexDataAttribute) 
                        {
                            ReadCharacter(prop.GetValue(character), result);
                        }
                        if (attr is SheetnameAttribute)
                        {
                            sheetName = ((SheetnameAttribute)attr).Sheetname;
                        }

                        if (attr is MinMaxAttribute)
                        {
                            var tmp = (MinMaxAttribute)attr;
                            minMax = (tmp.Min, tmp.Max);
                        }
                    }

                    if (string.IsNullOrEmpty(sheetName)) continue;

                    var wert = prop.GetValue(character);
                    if (wert is int) 
                    { 
                        int wertAsInt = (int)wert;  
                        if (wertAsInt < minMax.Item1)
                        {
                            wertAsInt = minMax.Item1;
                        }
                        if (wertAsInt > minMax.Item2)
                        {
                            wertAsInt = minMax.Item2;
                        }
                        wert = wertAsInt;
                    }
                    result.Add(sheetName, wert is null ? "" : wert.ToString());

                }
                catch (Exception ex)
                {
                    ex.Data.Add("Schlüssel", prop.PropertyType.Name);
                    throw;
                }

            }
            
        }
        public void CreateCharakterSheet(Character character)
        {

        }
    }
}
