using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    public class WeaponResources
    {
        private static Dictionary<string, List<Weapon>> _allWeapons = new Dictionary<string, List<Weapon>>();
        public static Dictionary<string, List<Weapon>> AllWeapons
        {
            get
            {
                if (_allWeapons.Count == 0)
                {
                    _allWeapons = new WeaponResources().CreateWeaponResources();
                }
                return _allWeapons;
            }
        }

        internal static List<Weapon> GetDefaultWeaponsForCareer(string career)
        {
            var defaultWeapons = new List<Weapon>();
            switch (career)
            {
                case Constants.Career.PILOT:
                    defaultWeapons.Add(GetRandomHandgun());
                    break;

                case Constants.Career.MARINE:
                    defaultWeapons.Add(AllWeapons[Constants.Weapon.TYPE.RIFLE][0]);
                    break;

                case Constants.Career.HEAVY_GUNNER:
                    defaultWeapons.Add(AllWeapons[Constants.Weapon.TYPE.HEAVY_WEAPON][0]);
                    defaultWeapons.Add(GetRandomHandgun());
                    break;

                case Constants.Career.TECH:
                    defaultWeapons.Add(AllWeapons[Constants.Weapon.TYPE.RIFLE][3]);
                    break;

                default:
                    defaultWeapons.Add(GetRandomHandgun());
                    break;
            }           
            return defaultWeapons;
        }

        private static readonly Random RandomGen = new();
        private static Weapon GetRandomHandgun()
        {            
            int max = AllWeapons[Constants.Weapon.TYPE.HANDGUN].Count - 1;
            int min = 0;
            int result = RandomGen.Next(min, max);
            return AllWeapons[Constants.Weapon.TYPE.HANDGUN][result];
        }

        public Dictionary<string, List<Weapon>> CreateWeaponResources()
        {
            return new Dictionary<string, List<Weapon>>
            {
                {
                    Constants.Weapon.TYPE.RIFLE,
                    new List<Weapon>()
                {
                    new Weapon() {Name = "Armat M41A Impulsgewehr", Bonus = "+1", Damage = 2, Range = Constants.Weapon.REICHWEITE.WEIT, Weight = 1, Special = {Constants.Weapon.SPEZIAL.PANZERBRECHEND } },
                    new Weapon() {Name = "AK-4047 Impuls-Sturmgewehr", Bonus = "-", Damage = 2, Range = Constants.Weapon.REICHWEITE.WEIT, Weight = 1, Special = {Constants.Weapon.SPEZIAL.VOLL_AUTO } },
                    new Weapon() {Name = "Armat M42A Präzisionsgewehr", Bonus = "+2", Damage = 2, Range = Constants.Weapon.REICHWEITE.EXTREM, Weight = 1, Special = {Constants.Weapon.SPEZIAL.PANZERBRECHEND} },
                    new Weapon() {Name = "Armat M37A2 Pumpgun Kaliber 12", Bonus = "+2", Damage = 3, Range = Constants.Weapon.REICHWEITE.KURZ, Weight = 1, Special = {Constants.Weapon.SPEZIAL.DOPPELTE_PANZERUNG } },
                    new Weapon() {Name = "SpaceSub ASSO-400 Harpunenkanone", Bonus = "-", Damage = 1, Range = Constants.Weapon.REICHWEITE.MITTEL, Weight = 1, Special = {Constants.Weapon.SPEZIAL.EINSCHUESSIG } },
                    new Weapon() {Name = "Armat XM99A Phasen-Plasma-Impulsgewehr", Bonus = "-", Damage = 4, Range = Constants.Weapon.REICHWEITE.EXTREM, Weight = 2, Special = {Constants.Weapon.SPEZIAL.EINSCHUESSIG  } },
                    new Weapon() {Name = "Armat M39 Submachine Gun", Bonus = "-1", Damage = 2, Range = Constants.Weapon.REICHWEITE.MITTEL, Weight = 1, Special = {Constants.Weapon.SPEZIAL.VOLL_AUTO  } },
                }
                },
                {
                    Constants.Weapon.TYPE.HANDGUN,
                    new List<Weapon>()
                {
                    new Weapon() {Name = "Revolver .357 Magnum", Bonus = "+1", Damage = 2, Range = Constants.Weapon.REICHWEITE.MITTEL, Weight = 1, },
                    new Weapon() {Name = "Armat M4A3 Dienstpistole", Bonus = "+2", Damage = 1, Range = Constants.Weapon.REICHWEITE.MITTEL, Weight = 0.5 },
                    new Weapon() {Name = "Rexim RXF-M5 Außenbordpistole", Bonus = "+1", Damage = 1, Range = Constants.Weapon.REICHWEITE.MITTEL, Weight = 0.5, Special = {Constants.Weapon.SPEZIAL.PANZERBRECHEND } },
                    new Weapon() {Name = "Heckler & Koch VP78 Pistol", Bonus = "+1", Damage = 1, Range = Constants.Weapon.REICHWEITE.MITTEL, Weight = 0.5, Special = {Constants.Weapon.SPEZIAL.BURST_PLUS_EINS, Constants.Weapon.SPEZIAL.VOLL_AUTO } },
                }

                },
                {
                    Constants.Weapon.TYPE.HEAVY_WEAPON ,
                    new List<Weapon>()
                {                    
                    new Weapon() {Name = "Armat U1 Granatwerfer", Bonus = "+1", Damage = 2, Range = Constants.Weapon.REICHWEITE.WEIT, Weight = 0.5, Special = {Constants.Weapon.SPEZIAL.ANDERE_GRANATEN, Constants.Weapon.SPEZIAL.EXPLOSION } },
                    new Weapon() {Name = "Armat M41A Impulsgewehr", Bonus = "-", Damage = 2, Range = Constants.Weapon.REICHWEITE.WEIT, Weight = 1, Special = {Constants.Weapon.SPEZIAL.PANZERBRECHEND } },
                    new Weapon() {Name = "M56A2 „Smartgun", Bonus = "+3", Damage = 3, Range = Constants.Weapon.REICHWEITE.WEIT, Weight = 3, Special = {Constants.Weapon.SPEZIAL.PANZERBRECHEND } },
                    new Weapon() {Name = "M240 Verbrennungseinheit", Bonus = "-", Damage = 2, Range = Constants.Weapon.REICHWEITE.MITTEL, Weight = 1, Special = {Constants.Weapon.SPEZIAL.FEUERINTENSITÄT_9 } },
                    new Weapon() {Name = "UA 571-C Geschützturm", Bonus = "+2", Damage = 4, Range = Constants.Weapon.REICHWEITE.EXTREM, Weight = 0, Special = {Constants.Weapon.SPEZIAL.PANZERBRECHEND, Constants.Weapon.SPEZIAL.VOLL_AUTO, Constants.Weapon.SPEZIAL.FERNKAMPF_8} },
                }

                },
            };
        }
    }
}
