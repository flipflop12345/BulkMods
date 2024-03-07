using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BulkMods.Towers;
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
using static BulkMods.BulkMods;

namespace BulkMods.Upgrades.ExampleMonkeyUpgrades
{
    internal class ExampleMonkeyMiddle1 : ModUpgrade<ExampleMonkey>
    {
        public override int Path => MIDDLE;

        public override int Tier => 1;

        public override int Cost => 250;

        public override string Portrait => "ExampleUpgrade-Portrait";
        public override string Icon => "ExampleUpgrade-Icon";

        public override void ApplyUpgrade(TowerModel towerModel)
        {
            var attackModel = towerModel.GetAttackModel();
            var weaponModel = towerModel.GetWeapon();
            var projectileModel = weaponModel.projectile;

            // Adding a new Weapon
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("EngineerMonkey-002").GetWeapon().Duplicate());
            attackModel.AddWeapon(Game.instance.model.GetTowerFromId("DartMonkey-005").GetWeapon().Duplicate());

            //create an ability
            Il2CppReferenceArray<Model> models = new(0);

            models.AddTo(new TurboModel("TurboModel_", 10f, 6f, null, 2, 1.5f, true));
            models.AddTo(new IncreaseRangeModel("IncreaseRangeModel_", 5000, 3.5f, 10.6f, true));
            models.AddTo(new ImfLoanModel("ImfLoanModel_", 9000.0f, 0.5f, new(), 1.0f));
            models.AddTo(new DamageUpModel("DamageUpModel_", 9999, 500, null));

            var ability = new AbilityModel("exampleAbility", "Example Ability", "this is an example ability", 0, 0, GetSpriteReference(Icon), 15f, models, false, false, null, 0f, 0, 1, false, false);
            towerModel.AddBehavior(ability);

            //range
            towerModel.range += 10;
            attackModel.range += 10;

            //speed
            weaponModel.rate *= 0.9f;

            //damage + pierce
            projectileModel.pierce += 30;
            projectileModel.GetDamageModel().damage += 5;
        }
    }

    internal class ExampleMonkeyMiddle2 : ModUpgrade<ExampleMonkey>
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

    internal class ExampleMonkeyMiddle3 : ModUpgrade<ExampleMonkey>
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

            weaponModel.rate *= AttackSpeedMultipllier;

            weaponModel.projectile.pierce += Pierce;
            weaponModel.projectile.GetDamageModel().damage += Damage;
        }
    }
}
