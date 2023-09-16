using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;

namespace ShotgunMonkey.Upgrades.TopPath
{
    public class RoboShotty : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 3;
        public override int Cost => 3000;

        public override string Description => "Robotic shotgun spam is very deadly and very fast for bloons";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<RoboShotgunMonkey>();
            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.Rate *= 0.22222f;
            weapon.projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.None;
        }
    }
}
