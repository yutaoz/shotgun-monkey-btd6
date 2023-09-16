using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace ShotgunMonkey.Upgrades.MiddlePath
{
    public class EvenMorePellets : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => MIDDLE;
        public override int Tier => 2;
        public override int Cost => 800;

        public override string Description => "Adds even more pellets to the wacky shotgun!";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<MorePelletsMonkey>();
            towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 10, 0, 30, null, false, false);
        }
    }
}
