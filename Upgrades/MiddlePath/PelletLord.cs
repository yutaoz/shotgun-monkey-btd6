using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;


namespace ShotgunMonkey.Upgrades.MiddlePath
{
    public class PelletLord : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 5;
        public override int Cost => 55400;

        public override string Description => "The Pellet Lord has arrived";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.range += 40;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range += 40;
            towerModel.ApplyDisplay<PelletLordMonkey>();

            var abmonkey = Game.instance.model.GetTowerFromId("WizardMonkey-040");
            var ability = abmonkey.GetAbility().Duplicate();

            var pelletlord = ability.GetDescendant<AbilityCreateTowerModel>().towerModel;


            pelletlord.ApplyDisplay<MarineMonkey>();

            var pelletspitter = pelletlord.GetAttackModel().weapons[0];


            pelletspitter.emission = new ArcEmissionModel("ArcEmissionModel_", 10, 0, 20, null, false, true);

            var emissionrotation = new EmissionRotationOffBloonDirectionModel("EmissionRotationOffBloonDirectionModel", false, true);
            pelletspitter.emission.AddBehavior(emissionrotation);
            pelletspitter.projectile.ApplyDisplay<BulletDisplay>();
            pelletspitter.projectile.GetDamageModel().damage += 4;
            pelletspitter.projectile.pierce += 10;


            towerModel.AddBehavior(ability);

            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.rate *= 0.3f;
            

            var projectile = weapon.projectile;
            projectile.pierce += 40;
            projectile.GetDamageModel().damage += 10;
        }
    }
}
