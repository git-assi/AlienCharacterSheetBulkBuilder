using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienCharBuilderLogic.Models
{
    public class AirVehicle : Vehicle
    {

    }

   
    public class AirVehicleFactory
    {
        public List<AirVehicle> CreateAirVehicles()
        {

            var result = new List<AirVehicle>();

            //result.Add(new AirVehicle() { Name = "", Geschwindigkeit = 0, Manoevrierbarkeit = 0, Panzerung = 0, Passagiere = 0, Rumpf = 0 });
            result.Add(new AirVehicle() { Name = "UD-4L \"Cheyenne\" Abwurfschiff", Geschwindigkeit = 15, Manoevrierbarkeit = "+2", Panzerung = 4, Passagiere = 10, Rumpf = 7 });
            result.Add(new AirVehicle() { Name = "CL-11 \"Atlas\" Heavy Lift Cargo Shuttle", Geschwindigkeit = 8, Manoevrierbarkeit = "-", Panzerung = 1, Passagiere = 4, Rumpf = 6 });
            return result;
        }
    }
}
