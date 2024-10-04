using AlienCharBuilderLogic.Models;

namespace AlienCharBuilderLogic.Factory
{
    internal class GenericTalentFactory
    {
        public Talent GetRandomGenericTalent()
        {
            return new Talent() { Category = Constants.Talent.GENERAL, Description = "Platzhalter", Name = "RandomGenericTalent" };
        }
    }
}
