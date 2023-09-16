using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;

namespace ShotgunMonkey.Upgrades.BottomPath
{
    public class LawnDefender : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => BOTTOM;
        public override int Tier => 3;
        public override int Cost => 1200;

        public override string Description => "Spots those dirty bloons from afar";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<LawnDefenderMonkey>();
            towerModel.range += 30;
            towerModel.GetAttackModel().range += 30;

            var weapon = towerModel.GetAttackModel().weapons[0];
            weapon.Rate *= 0.8f;
        }
    }
}
