using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace TaikoStar.Modules.RPC;

public class RPCMonoBehavior(IntPtr handle): MonoBehaviour(handle) {
    private void OnEnable() {
        SceneManager.sceneLoaded += (UnityAction<Scene, LoadSceneMode>) OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        RPCHelpers.SceneChange(scene, mode);
    }
}