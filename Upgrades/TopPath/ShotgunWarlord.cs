using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;

namespace ShotgunMonkey.Upgrades.TopPath
{
    public class ShotgunWarlord : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 5;
        public override int Cost => 53000;

        public override string Description => "The king of removing bloons";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay <WarlordShotgunMonkey>();
            var weapon = towerModel.GetAttackModel().weapons[0];
            var projectile = weapon.projectile;
            weapon.Rate *= 0.5f;
            projectile.pierce = 1000;
            projectile.GetDamageModel().damage += 3;
            
            projectile.GetBehavior<TravelStraitModel>().Lifespan = 20.0f;
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",
                1, 30, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified",
                "Fortified",
                1, 30, false, false));
            projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Moabs", "Moabs",
                1, 100, false, false));


        }
    }
}
