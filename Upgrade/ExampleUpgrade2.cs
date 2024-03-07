using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkMods.Upgrade
{
    internal class ExampleUpgrade2 : ModUpgrade<ExampleMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 2;

        public override int Cost => 250;

        public override string Portrait => "ExampleUpgrade2-Portrait";
        public override string Icon => "ExampleUpgrade2-Icon";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon();
            var projectileModel = weaponModel.projectile;

            //multishot
            weaponModel.emission = new ArcEmissionModel("ArcEmissionModel_", 3, 0, 25, null, false, false);

            //behaviors
            //weaponModel.projectile.AddBehavior(new TrackTargetModel("TrackTargetModel_", 100f, true, true, 360f, false, 360f, false, false));
            weaponModel.projectile.AddBehavior(Game.instance.model.GetTower("WizardMonkey", 2).GetWeapon().projectile.GetBehavior<TrackTargetModel>().Duplicate());
            weaponModel.projectile.AddBehavior(new CashModel("CashModel_", 5, 5, 0, 0, false, false, false, false, true));
            weaponModel.projectile.AddBehavior<CreateProjectileOnExhaustFractionModel>(new("CreateProjectileOnExhaustFractionModel_", weaponModel.projectile.Duplicate(), new ArcEmissionModel("ArcEmissionModel_", 2, 0, 45, null, false, false), 0.5f, 0.33333f, false, false, false));

            towerModel.GetDescendants<FilterInvisibleModel>().ForEach(model => model.isActive = false); // Camo
            weaponModel.projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.Frozen | Il2Cpp.BloonProperties.White; // Makes it so that the tower can pop everything but frozen and white
        }
    }
}
