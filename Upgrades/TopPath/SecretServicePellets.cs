using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using ShotgunMonkey.Displays;

namespace ShotgunMonkey.Upgrades.TopPath
{
    public class SecretServicePellets : ModUpgrade<ShotgunMonkey>
    {
        public override int Path => TOP;
        public override int Tier => 1;
        public override int Cost => 500;

        public override string Description => "Pellets stolen from government agencies have more pierce";

        public override string Portrait => "ShotgunMonkey-Portrait";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            towerModel.ApplyDisplay<PierceShotgunMonkey>();
            var projectile = towerModel.GetAttackModel().weapons[0].projectile;
            projectile.pierce += 2;
        }
    }
}
