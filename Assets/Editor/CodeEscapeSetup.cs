using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[InitializeOnLoad]
public static class CodeEscapeSetup
{
    static CodeEscapeSetup()
    {
        EditorApplication.delayCall += EnsureScene;
    }

    private static void EnsureScene()
    {
        const string path = "Assets/Scenes/Main.unity";
        if (System.IO.File.Exists(path)) return;
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var game = new GameObject("Code Escape Game");
        game.AddComponent<CodeEscapeGame>();
        EditorSceneManager.SaveScene(scene, path);
        EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene(path, true) };
        Debug.Log("Code Escape is ready. Open Assets/Scenes/Main.unity and press Play.");
    }
}
