using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace ShotgunMonkey.Upgrades.TopPath
{
    public class SeekingShotty : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 4;
        public override int Cost => 4000;

        public override string Description => "Alien tech hunts down bloons";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<RoboShotgunMonkey>();
            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.emission.AddBehavior(
                new EmissionRotationOffBloonDirectionModel("EmissionRotationOffBloonDirectionModel", false, false));
            
            var projectile = weapon.projectile;
            towerModel.GetAttackModel().attackThroughWalls = true;
            projectile.pierce = 20;
            /*projectile.RemoveBehavior<RotateModel>();
            projectile.GetBehavior<RetargetOnContactModel>().distance = 2000;*/
            projectile.GetBehavior<TravelStraitModel>().Lifespan = 5.0f;
            projectile.AddBehavior(
                new RetargetOnContactModel("RetargetOnContactModel", 2000, 10, null, 0.05f, true));


        }
    }
}
