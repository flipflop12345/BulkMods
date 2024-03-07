using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkMods.Upgrade
{
    internal class ExampleUpgrade : ModUpgrade<ExampleMonkey>
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
}
