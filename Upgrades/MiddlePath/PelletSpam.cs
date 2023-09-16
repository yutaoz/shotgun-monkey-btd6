using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace ShotgunMonkey.Upgrades.MiddlePath
{
    public class PelletSpam : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 3;
        public override int Cost => 2200;

        public override string Description => "Just straight up spams those pellets";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<PelletSpamMonkey>();
            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.Rate *= 0.4f;
            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 20, 0, 45, null, false, false);
        }
    }
}
