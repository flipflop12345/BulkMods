using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Enums;
using BulkMods.Bloons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkMods.Display
{
    internal class ExampleBloonDisplay : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Green);

        public override float Scale => 2;
    }

    internal class ExampleBloonDamage1Display : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Green);

        public override float Scale => 1.75f;

        public override int Damage => 1;
    }

    internal class ExampleBloonDamage2Display : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Green);

        public override float Scale => 1.5f;

        public override int Damage => 2;
    }

    internal class ExampleBloonDamage3Display : ModBloonDisplay<ExampleBloon>
    {
        public override string BaseDisplay => GetBloonDisplay(BloonType.Green);

        public override float Scale => 1.25f;

        public override int Damage => 3;
    }
}
