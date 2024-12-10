using System.Diagnostics.CodeAnalysis;
using UnityEngine.SceneManagement;

namespace TaikoStar.Modules.RPC;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class RPCHelpers {
    private static readonly DiscordRichPresence Instance = DiscordRichPresence.Instance;

    public static void SceneChange(Scene scene, LoadSceneMode mode) {
        switch (scene.name) {
            case "Boot":
                Instance.RichPresence.Details = "ゲームをロード中...";
                Instance.RichPresence.State = "";
                Instance.RichPresence.Assets.SmallImageKey = "";
                Instance.RichPresence.Assets.SmallImageText = "";
                break;
            case "Title":
                Instance.RichPresence.Details = "タイトル画面";
                Instance.RichPresence.State = "";
                Instance.RichPresence.Assets.SmallImageKey = "";
                Instance.RichPresence.Assets.SmallImageText = "";
                break;
            case "MainMenu":
                Instance.RichPresence.Details = "オミコシティ: モード選択中";
                Instance.RichPresence.State = "";
                Instance.RichPresence.Assets.SmallImageKey = "";
                Instance.RichPresence.Assets.SmallImageText = "";
                break;
            case "ThunderShrine":
                Instance.RichPresence.Details = "雷音神社: モード選択中";
                Instance.RichPresence.State = "";
                Instance.RichPresence.Assets.SmallImageKey = "";
                Instance.RichPresence.Assets.SmallImageText = "";
                break;
            case "SongSelect":
                Instance.RichPresence.Details = "譜面選択中";
                Instance.RichPresence.State = "演奏ゲーム";
                Instance.RichPresence.Assets.SmallImageKey = "";
                Instance.RichPresence.Assets.SmallImageText = "";
                break;
            case "SongSelectTraining":
                Instance.RichPresence.Details = "譜面選択中";
                Instance.RichPresence.State = "トレーニング";
                Instance.RichPresence.Assets.SmallImageKey = "";
                Instance.RichPresence.Assets.SmallImageText = "";
                break;
            case "Enso":
                EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.Normal;
                break;
            case "EnsoScenario":
                EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.Scenario;
                break;
            case "EnsoTrainingFull":
                EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.Training;
                break;
            case "EnsoDonChanBand":
                EnsoHelpers.CurrentEnsoType = EnsoHelpers.EnsoType.DonChanBand;
                break;
        }
        
        Instance.UpdatePresence();
    }
}