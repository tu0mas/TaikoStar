using System.Diagnostics.CodeAnalysis;
using HarmonyLib;

namespace TaikoStar.Patches;

[HarmonyPatch]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SkipCoinAndReward {
    [HarmonyPatch(typeof(ResultPlayer), nameof(ResultPlayer.SettingDonCoinAndReward))]
    [HarmonyPostfix]
    public static void SettingDonCoinAndReward_Postfix(ResultPlayer __instance)
    {
        __instance.isSkipCoinAndReward = true;
    }
}