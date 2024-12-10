using System.Diagnostics.CodeAnalysis;
using DiscordRPC;
using DiscordRPC.Logging;
using TaikoStar.Patches;

namespace TaikoStar.Modules.RPC;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class DiscordRichPresence {
    public static DiscordRichPresence Instance { get; } = new();

    private DiscordRpcClient rpc;
    
    private const string ClientId = "1309050701800017970";
    
    public readonly RichPresence RichPresence = new() {
        Details = "初期化中...",
        State = "",
        Timestamps = Timestamps.Now,
        Assets = new DiscordRPC.Assets()
    };

    public void Initialize() {
        SongInfoPlayerPatcher.Instance.OnSongInfoPlayerFinished += EnsoHelpers.SetEnso;
        
        rpc = new DiscordRpcClient(ClientId);
        
        rpc.Logger = new ConsoleLogger {
            Level = LogLevel.Warning,
            Coloured = true
        };

        rpc.OnReady += (sender, e) => {
            Plugin.Log.LogInfo($"Ready has been received from user {e.User.Username}");
            UpdatePresence();
        };
        
        rpc.OnPresenceUpdate += (sender, e) => {
            Plugin.Log.LogInfo($"Update received! {e.Presence.Details}, {e.Presence.State}");
        };

        rpc.Initialize();
    }
    
    public void UpdatePresence() => rpc.SetPresence(RichPresence);
}