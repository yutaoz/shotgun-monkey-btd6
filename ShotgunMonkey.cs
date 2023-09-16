using System.Collections.Generic;
using System.Linq;
using MelonLoader;
using BTD_Mod_Helper;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey;
using ShotgunMonkey.Displays;

/*[assembly: MelonInfo(typeof(ShotgunMonkey.ShotgunMonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]*/

namespace ShotgunMonkey
{

    public class ShotgunMonkey : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;
        public override string BaseTower => TowerType.DartMonkey;
        public override int Cost => 600;
        public override int TopPathUpgrades => 5;
        public override int MiddlePathUpgrades => 5;
        public override int BottomPathUpgrades => 5;
        public override string Description => "Monkey that bought a shotgun";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 5, 0, 30, null, false, false);
            
            towerModel.range = 26;
            var attackModel = towerModel.GetAttackModel();
            attackModel.range = 26;

            var weapon = attackModel.weapons[0];
            weapon.Rate *= 3;

            var projectile = weapon.projectile;
            projectile.ApplyDisplay <BulletDisplay>();
            //projectile.pierce += 1;

            
        }

        public override int GetTowerIndex(List<TowerDetailsModel> towerSet)
        {
            return towerSet.First(model => model.towerId == TowerType.BoomerangMonkey).towerIndex + 1;
        }
        /*public override void OnApplicationStart()
        {
            ModHelper.Msg<ShotgunMonkey>("ShotgunMonkey loaded!");
        }*/
    }
}