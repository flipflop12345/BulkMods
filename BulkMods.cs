using MelonLoader;
using BTD_Mod_Helper;
using BulkMods;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(BulkMods.BulkMods), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace BulkMods;

public class BulkMods : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<BulkMods>("BulkMods loaded!");
    }

    //Setting menu in btd6
    public static readonly ModSettingCategory Category = new("Teir 3 options")
    {
        icon = "Cog1.png"
    };

    [System.Obsolete]
    public static readonly ModSettingInt Damage = new(5)
    {
        requiresRestart = true,
        category = Category,
        isSlider = true,
        minValue = 1,
        maxValue = 50,
        description = "Example description",
    };

    public static readonly ModSettingInt Range = new(75)
    {
        requiresRestart = true,
        category = Category,
        description = "What range is set to?",
    };

    public static readonly ModSettingInt Pierce = new(16)
    {
        requiresRestart = true,
        category = Category,
        description = "What pierce is set to?",
    };

    public static readonly ModSettingInt Cost = new(750)
    {
        requiresRestart = true,
        category = Category,
        description = "Example description",
    };

    public static readonly ModSettingDouble AttackSpeedMultipllier = new(0.5)
    {
        requiresRestart = true,
        category = Category,
        description = "what the attack speed is multiplied by"
    };
}