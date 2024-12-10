using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Scripts.Common;
using Scripts.OutGame.Title;

namespace TaikoStar.Patches;

[HarmonyPatch]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class ReplaceVersionText {
    [HarmonyPatch(typeof(TitleSceneUiController), "Setup")]
    [HarmonyPostfix]
    private static void TitleSceneUiController_Postfix(TitleSceneUiController __instance) {
        try {
            var properties = typeof(TitleSceneUiController).GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            var appVersionProperty = properties.FirstOrDefault(p => p.Name == "AppVersion");
            if (appVersionProperty == null) return;
                
            var uiText = appVersionProperty.GetValue(__instance) as UiText;
            if (uiText == null) return;
                
            uiText.SetTextRaw("TaikoStar v" + MyPluginInfo.PLUGIN_VERSION);
        }
        catch (Exception ex) {
            Plugin.Log.LogError($"Error accessing AppVersion property: {ex}");
        }
    }
}