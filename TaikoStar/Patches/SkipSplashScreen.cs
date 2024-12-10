using System.Diagnostics.CodeAnalysis;
using HarmonyLib;
using Scripts.OutGame.Boot;
using Scripts.OutGame.Common;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TaikoStar.Patches;

[HarmonyPatch]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class SkipSplashScreen {
    private const float newDuration = 0f;
    
    private static bool IsBootScene() {
        return SceneManager.GetActiveScene().name == "Boot";
    }
    
    [HarmonyPatch(typeof(BootSceneUiController), nameof(BootSceneUiController.Method_Private_UniTask_Single_Boolean_0))]
    [HarmonyPrefix]
    public static bool SkipBootSceneFade_Prefix(BootSceneUiController __instance, ref float duration) {
        duration = 0f;
        
        return true;
    }

    [HarmonyPatch(typeof(BootImage), nameof(BootImage.PlayAsync))]
    [HarmonyPrefix]
    public static bool PlayAsync_Prefix(BootImage __instance, ref float duration, ref bool skippable) {
        duration = 0f;
        skippable = true;
        
        return true;
    }

    [HarmonyPatch(typeof(FadeCover), nameof(FadeCover.FadeInAsync))]
    [HarmonyPatch(typeof(FadeCover), nameof(FadeCover.FadeOutAsync))]
    [HarmonyPrefix]
    public static bool SkipFade_Prefix(FadeCover __instance, ref Color color, ref float duration) {
        if (IsBootScene()) duration = newDuration;

        return true;
    }
}