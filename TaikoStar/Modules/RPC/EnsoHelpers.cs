using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace TaikoStar.Modules.RPC;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class EnsoHelpers {
    private static readonly DiscordRichPresence Instance = DiscordRichPresence.Instance;

    public static EnsoType CurrentEnsoType;
    
    public enum EnsoType {
        Normal,
        Scenario,
        Training,
        DonChanBand
    }

    private static void GenreRPCState(EnsoData.SongGenre songGenre) {
        switch (songGenre) {
            case EnsoData.SongGenre.Pops:
                Instance.RichPresence.State = "ポップス";
                break;
            case EnsoData.SongGenre.Anime:
                Instance.RichPresence.State = "アニメ";
                break;
            case EnsoData.SongGenre.Vocalo:
                Instance.RichPresence.State = "ボーカロイド™️曲";
                break;
            case EnsoData.SongGenre.Variety:
                Instance.RichPresence.State = "バラエティ";
                break;
            case EnsoData.SongGenre.Classic:
                Instance.RichPresence.State = "クラシック";
                break;
            case EnsoData.SongGenre.Game:
                Instance.RichPresence.State = "ゲームミュージック";
                break;
            case EnsoData.SongGenre.Namco:
                Instance.RichPresence.State = "ナムコオリジナル";
                break;
        }
    }
    
    private static void LevelRPCImage(EnsoData.EnsoLevelType ensoLevel) {
        Plugin.Log.LogInfo($"ensoLevel: {ensoLevel}");
        switch (ensoLevel) {
            case EnsoData.EnsoLevelType.Easy:
                Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_easy.png";
                Instance.RichPresence.Assets.SmallImageText = "かんたん";
                break;
            case EnsoData.EnsoLevelType.Normal:
                Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_normal.png";
                Instance.RichPresence.Assets.SmallImageText = "ふつう";
                break;
            case EnsoData.EnsoLevelType.Hard:
                Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_hard.png";
                Instance.RichPresence.Assets.SmallImageText = "むずかしい";
                break;
            case EnsoData.EnsoLevelType.Mania:
                Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_mania.png";
                Instance.RichPresence.Assets.SmallImageText = "おに";
                break;
            case EnsoData.EnsoLevelType.Ura:
                Instance.RichPresence.Assets.SmallImageKey = "https://nmkmn.moe/taiko/icon_course_ura.png";
                Instance.RichPresence.Assets.SmallImageText = "おに（裏）";
                break;
        }
    }
    
    private static void EnsoScreenRPC(EnsoType ensoType, string songName, EnsoData.SongGenre songGenre,
        EnsoData.EnsoLevelType ensoLevel) {
        switch (ensoType) {
            case EnsoType.Normal:
                Instance.RichPresence.Details = songName;
                Instance.RichPresence.Assets.LargeImageText = "ノーマル";
                GenreRPCState(songGenre);
                LevelRPCImage(ensoLevel);
                break;
            case EnsoType.Scenario:
                Instance.RichPresence.Details = songName;
                Instance.RichPresence.Assets.LargeImageText = "シナリオ";
                GenreRPCState(songGenre);
                LevelRPCImage(ensoLevel);
                break;
            case EnsoType.Training:
                Instance.RichPresence.Details = songName;
                Instance.RichPresence.Assets.LargeImageText = "トレーニング";
                GenreRPCState(songGenre);
                LevelRPCImage(ensoLevel);
                break;
            case EnsoType.DonChanBand:
                Instance.RichPresence.Details = songName;
                Instance.RichPresence.Assets.LargeImageText = "どんちゃんバンド";
                GenreRPCState(songGenre);
                LevelRPCImage(ensoLevel);
                break;
        }
        
        Instance.UpdatePresence();
    }
    
    public static void SetEnso(object sender, EventArgs args) {
        if (sender is not SongInfoPlayer songInfoPlayer) return;
        
        var ensoDataManager = GameObject.Find("CommonObjects/Datas/EnsoDataManager").GetComponent<EnsoDataManager>();
        var ensoLevelDifficulty = ensoDataManager.GetDiffCourse(0);
        
        EnsoScreenRPC(CurrentEnsoType, songInfoPlayer.m_SongName, songInfoPlayer.m_Genre, ensoLevelDifficulty);
    }
}