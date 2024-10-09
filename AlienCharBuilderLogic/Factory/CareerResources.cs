using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    public class CareerResources
    {
        private Dictionary<string, Career> _allCareers = new Dictionary<string, Career>();
        public Dictionary<string, Career> AllCareers
        {
            get
            {
                if (_allCareers.Count == 0)
                {
                    _allCareers = new CareerResources().CreateResources();
                }
                return _allCareers;
            }
        }

        private Dictionary<string, Career> CreateResources()
        {
            var result = new Dictionary<string, Career>();
            foreach (var item in Constants.Career.All)
            {
                result.Add(item, CreateCareer(item));
            }
            return result;
        }

        private WeaponResources _weaponResources = new WeaponResources();

        private Career CreateCareer(string name)
        {
            return new Career()
            {
                Name = name,
                Baserank = GetDefaultRankForCareer(name),
                DefaultWeapons = _weaponResources.GetDefaultWeaponsForCareer(name),
            };
        }

        private string GetDefaultRankForCareer(string career)
        {
            switch (career)
            {
                case Constants.Career.PILOT:
                    return Constants.Rank.CORPORAL;

                case Constants.Career.OFFICER:
                    return Constants.Rank.LIEUTENANT;

                case Constants.Career.SERGANT:
                    return Constants.Rank.SERGANT;

                case Constants.Career.MARINE:
                    return Constants.Rank.PRIVATE;

                case Constants.Career.HEAVY_GUNNER:
                    return Constants.Rank.PRIVATE_FC;

                case Constants.Career.TECH:
                case Constants.Career.MEDIC:
                    return Constants.Rank.SPECIALIST;

                case Constants.Career.WEAPONS_OFFICER:
                    return Constants.Rank.WARRANT_OFFICER;

                default:
                    return Constants.Rank.PRIVATE;
            }
        }

        internal Career GetCareer(string career)
        {
            if (AllCareers.ContainsKey(career))
            {
                return AllCareers[career];
            }
            else
            {
                return new Career() { Name = "huh?" };
            }

        }
    }
}

