using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace ShotgunMonkey.Upgrades.BottomPath
{
     public class Gatekeeper : ModUpgrade<ShotgunMonkey> 
    {
        public override int Path => BOTTOM;
        public override int Tier => 4;
        public override int Cost => 10800;

        public override string Description => "GATEKEEPS ALL BLOONS FROM ENTRY";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += 30;
            towerModel.GetAttackModel().range += 30;

            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.Rate *= 0.8f;

            var projectile = weapon.projectile;
            projectile.GetBehavior<WindModel>().affectMoab = true;
            projectile.pierce += 4;
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                1, 50, false, false));
        }
    }
}
