using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BulkMods.Display.ExampleMonkeyDisplayfldr;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkMods.Towers
{
    internal class ExampleMonkey : ModTower
    {
        public override TowerSet TowerSet => TowerSet.Primary;

        public override string BaseTower => TowerType.SuperMonkey; //alternatively, you can do "SuperMonkey-000" for a specific teir of the tower

        public override int Cost => 750;

        public override int BottomPathUpgrades => 0;

        public override int MiddlePathUpgrades => 3;

        public override int TopPathUpgrades => 0;

        public override string Description => "I Disagree";

        public override string DisplayName => "Negativity";

        public override string Portrait => "ExampleMonkey-Portrait";
        public override string Icon => "ExampleMonkey-Icon";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon();
            var projectileModel = weaponModel.projectile;

            //range
            towerModel.range += 25;
            attackModel.range += 25;

            //speed
            weaponModel.rate *= 0.75f;

            //damage + pierce
            projectileModel.pierce += 15;
            projectileModel.GetDamageModel().damage += 8;

            towerModel.ApplyDisplay<ExampleMonkeyDisplay>();
            projectileModel.ApplyDisplay<ExampleProjectileDisplay>();
        }
    }
}
