using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace ShotgunMonkey.Upgrades.MiddlePath
{
    public class PelletGang : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 4;
        public override int Cost => 14400;

        public override string Description => "MORE PELLETS";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {

            towerModel.towerSelectionMenuThemeId = "SelectPointInput";

            var abmonkey = Game.instance.model.GetTowerFromId("HeliPilot-050");

            var marine = abmonkey.GetDescendant<FindDeploymentLocationModel>().towerModel;
            var marineweapon = marine.GetWeapon();
            marineweapon.rate *= 1.1f;
            marineweapon.emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);

            var abilityModel = new AbilityModel("AbilityModel_PelletGang", "Pellet Gang", "Invites one of his boys with a shotgun", 1, 0, GetSpriteReference("SpecialPoperations"), 30f, null, false, false, null, 0, 0, 999999, false, false);
            towerModel.AddBehavior(abilityModel);

            var activateAttackModel = new ActivateAttackModel("ActivateAttackModel_PelletGang", 0, true, new Il2CppReferenceArray<AttackModel>(1), false, false, false, false, true);
            abilityModel.AddBehavior(activateAttackModel);

            var summoner = Game.instance.model.GetHeroWithNameAndLevel("Ezili", 7);

            var attackModel = activateAttackModel.attacks[0] = summoner.GetAbilities()[1].GetBehavior<ActivateAttackModel>().attacks[0].Duplicate();
            attackModel.GetDescendant<CreateTowerModel>().tower = marine;

            activateAttackModel.AddChildDependant(attackModel);

            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.rate *= 0.7f;

            var projectile = weapon.projectile;
            projectile.pierce += 4;
        }
    }
}
