
namespace Code.TowerDefense
{
    public interface IAbilityGroup
    {
        public void AddAbility<T>(T ability) where T : IAbility;
        public void UpgradeAbilityType<T>() where T : IAbility;
    }
}