using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BulkMods.BulkMods;

namespace BulkMods.Upgrade
{
    internal class CustomizableUpgrade : ModUpgrade<ExampleMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 3;

        public override int Cost => BulkMods.Cost;

        public override string Description => "Customizable options from setting menu";

        public override string Portrait => "CustomizableUpgrade-Portrait";
        public override string Icon => "CustomizableUpgrade-Icon";

        [Obsolete]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        public override void ApplyUpgrade(TowerModel towerModel)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
        {
            var weaponModel = towerModel.GetWeapon();

            towerModel.GetAttackModel().range += BulkMods.Range;
            towerModel.range += BulkMods.Range;

            weaponModel.rate *= BulkMods.AttackSpeedMultipllier;

            weaponModel.projectile.pierce += BulkMods.Pierce;
            weaponModel.projectile.GetDamageModel().damage += BulkMods.Damage;
        }
    }
}
