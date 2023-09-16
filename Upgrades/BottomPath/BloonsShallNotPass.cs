using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace ShotgunMonkey.Upgrades.BottomPath
{
    public class BloonsShallNotPass : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 5;
        public override int Cost => 72400;

        public override string Description => "one must imagine blooniphus happy";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {

            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.Rate *= 0.6f;

            var projectile = weapon.projectile;
            projectile.GetBehavior<WindModel>().affectMoab = true;
            projectile.pierce += 15;
            projectile.GetDamageModel().damage += 10;

            var slowmonkey = Game.instance.model.GetTowerFromId("IceMonkey-050");
            var slowmodel = slowmonkey.GetDescendant<SlowBloonsZoneModel>().Duplicate();

            towerModel.AddBehavior(slowmodel);
        }
    }
}
