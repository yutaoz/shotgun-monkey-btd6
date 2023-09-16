using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace ShotgunMonkey.Upgrades.BottomPath
{
    public class AmericanMonkey : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 1;
        public override int Cost => 900;

        public override string Description => "American monkey wielding the freedom deliverer with extra powerful freedom pellets";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<AmericaMonkey>();
            var weapon = towerModel.GetAttackModel().weapons[0];
            
            var projectile = weapon.projectile;
            projectile.ApplyDisplay<AmericaPellets>();
            projectile.GetDamageModel().damage += 1;
            projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }
    }
}
