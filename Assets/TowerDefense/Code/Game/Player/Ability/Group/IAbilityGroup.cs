
namespace Code.TowerDefense
{
    public interface IAbilityGroup
    {
        public void AddAbility(IAbility ability);
        public void UpgradeAbilityType();
    }
}