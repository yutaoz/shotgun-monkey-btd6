using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace ShotgunMonkey.Upgrades.MiddlePath
{
    public class MorePellets : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 1;
        public override int Cost => 400;

        public override string Description => "Adds 2 more pellets to the wacky shotgun!";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<PelletsMonkey>();
            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 7, 0, 30, null, false, false);

        }
    }
}
