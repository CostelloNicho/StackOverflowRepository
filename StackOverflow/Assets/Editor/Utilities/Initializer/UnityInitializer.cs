#region Directives

using System.IO;
using UnityEditor;
using UnityEngine;

#endregion

public class UnityInitializer : EditorWindow
{
    private DirectoryInfo _assetsDirectory;
    private const string ReadMe = "README.md";
    private string[] directorys;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Utilities/Initialize Project")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        var window = (UnityInitializer) GetWindow(typeof (UnityInitializer));
        window.Show();
        window.Initialize();
    }

    public void Initialize()
    {
        _assetsDirectory = new DirectoryInfo(Application.dataPath);
        AddDirectory("Editor");
        AddDirectory("Scenes");
        AddDirectory("Scripts");
        AddDirectory("Art");
        AddDirectory("Materials");
        AddDirectory("Models");
        AddDirectory("Prefabs");
        AddDirectory("Plugins");
        AddDirectory("Resources");
        AddDirectory("Animations");
        Close();
    }

    private void AddDirectory(string dirName)
    {
        var directoryPath = _assetsDirectory.Name + "/" + dirName;
        var directoryNeedsCreation = !Directory.Exists(directoryPath);
        if (directoryNeedsCreation)
        {
            _assetsDirectory.CreateSubdirectory(dirName);
        }

        var filePath = directoryPath + "/" + ReadMe;
        var ReadmeNeedsCreate = !File.Exists(filePath);
        if (ReadmeNeedsCreate)
        {
            File.Create(filePath);
        }
    }
}