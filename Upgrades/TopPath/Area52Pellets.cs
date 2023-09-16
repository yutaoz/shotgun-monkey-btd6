using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;

namespace ShotgunMonkey.Upgrades.TopPath
{
    public class Area52Pellets : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 2;
        public override int Cost => 1000;

        public override string Description => "Unidentified pellets are much more powerful";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<AlienShotgunMonkey>();

            var projectile = towerModel.GetAttackModel().weapons[0].projectile;
            projectile.ApplyDisplay<LaserDisplay>();
            projectile.pierce += 2;
            projectile.GetDamageModel().damage += 2;
        }
    }
}
