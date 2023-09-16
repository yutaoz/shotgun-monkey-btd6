using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper.Api.Display;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers;
using BTD_Mod_Helper.Extensions;

namespace ShotgunMonkey.Displays
{
    public class BulletDisplay : ModDisplay//ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartlingGunner-004").GetWeapon().projectile.display.guidRef;


        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            
        }
    }

    public class AmericaPellets : ModDisplay
    {
        public override string BaseDisplay => Generic2dDisplay;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
            Set2DTexture(node, "AmericaPellet");
        }
    }

    public class LaserDisplay : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartlingGunner-300").GetWeapon().projectile.display.guidRef;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }
    }

    public class BaseShotgunMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartMonkey-004").display.guidRef;

        public override bool UseForTower(int[] tiers)
        {
            return tiers.Sum() == 0;
        }
    }

    public class PierceShotgunMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartMonkey-104").display.guidRef;

        public override bool UseForTower(int[] tiers)
        {
            return (tiers[0] == 1 && tiers[1] < 3 && tiers[2] < 3);
        }
    }

    public class AlienShotgunMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartMonkey-204").display.guidRef;

        public override bool UseForTower(int[] tiers)
        {
            return (tiers[0] == 2 && tiers[1] < 3 && tiers[2] < 3);
        }
    }


    // for some reason robomonkey displays get bugged out using modtowerdisplay so we use moddisplay
    public class RoboShotgunMonkey : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("SuperMonkey-030").display.guidRef;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }

        /*public override bool UseForTower(int[] tiers)
        {
            return tiers[0] == 1;
        }*/
    }

    public class WarlordShotgunMonkey : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("SuperMonkey-052").display.guidRef;

        public override void ModifyDisplayNode(UnityDisplayNode node)
        {

        }

        /*public override bool UseForTower(int[] tiers)
        {
            return tiers[0] == 5;
        }*/
    }

    public class PelletsMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartMonkey-014").display.guidRef;
            public override bool UseForTower(int[] tiers)
        {
            return (tiers[1] == 1 && tiers[0] < 3 && tiers[2] < 3);
        }
    }

    public class MorePelletsMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("DartMonkey-024").display.guidRef;
        public override bool UseForTower(int[] tiers)
        {
            return (tiers[1] == 2 && tiers[0] < 3 && tiers[2] < 3);
        }
    }


    // dartling uses a weird weapon element as its display so we have to dig through game code to find guid
    public class PelletSpamMonkey : ModDisplay
    {
        public override string BaseDisplay => "028a7597e522bb14688c8e2fc762f9b7";
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
        }
    }

    public class PelletLordMonkey : ModDisplay
    {
        public override string BaseDisplay => "6f840664a28838240834f66dff6b7189";
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
        }
    }

    public class MarineMonkey : ModDisplay
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("Marine").display.guidRef;
        public override void ModifyDisplayNode(UnityDisplayNode node)
        {
        }
    }

    public class AmericaMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("BoomerangMonkey-003").display.guidRef;

        public override bool UseForTower(int[] tiers)
        {
            return (tiers[2] == 1 && tiers[0] < 3 && tiers[1] < 3);
        }
    }

    public class LawnMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("BoomerangMonkey-103").display.guidRef;

        public override bool UseForTower(int[] tiers)
        {
            return (tiers[2] == 2 && tiers[0] < 3 && tiers[1] < 3);
        }
    }

    public class LawnDefenderMonkey : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("BoomerangMonkey-204").display.guidRef;

        public override bool UseForTower(int[] tiers)
        {
            return (tiers[2] == 3);
        }
    }

    public class BloonsShallNotPass : ModTowerDisplay<ShotgunMonkey>
    {
        public override string BaseDisplay => Game.instance.model.GetTowerFromId("BoomerangMonkey-205").display.guidRef;
        public override bool UseForTower(int[] tiers)
        {
            return (tiers[2] == 5);
        }
    }

}
