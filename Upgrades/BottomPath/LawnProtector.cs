using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;

namespace ShotgunMonkey.Upgrades.BottomPath
{
    public class LawnProtector : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 2;
        public override int Cost => 1020;

        public override string Description => "GET OFF MY LAWN! Knocks back bloons!";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<LawnMonkey>();
            towerModel.range += 10;
            towerModel.GetAttackModel().range += 10;

            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.Rate *= 0.6f;
            var projectile = weapon.projectile;

            /*var knockbackmonkey = Game.instance.model.GetTowerFromId("SuperMonkey-002");
            var knockbackmodel = knockbackmonkey.GetDescendant<KnockbackModel>().Duplicate();*/
            //projectile.collisionPasses = new[] { -1, 0 };
            var pushmonkey = Game.instance.model.GetTowerFromId("NinjaMonkey-030");
            var pushmodel = pushmonkey.GetDescendant<WindModel>().Duplicate();
            pushmodel.chance = 0.6f;
            
            projectile.AddBehavior(pushmodel);

        }
    }
}
