using UnityEditor;
using UnityEditor.AddressableAssets.Settings;

public static class AutoBuildAddressables
{
    private const string Title = "Adressables";
    private const string Message = "This project uses Addressables for it's content, if you havent built these already the player will fail to function correctly.";
    private const string Agree = "Build Adressables Now";
    private const string Disagree = "Ignore";

    [InitializeOnLoadMethod]
    private static void Initialize()
    {
        BuildPlayerWindow.RegisterBuildPlayerHandler(BuildPlayerHandler);
    }

    private static void BuildPlayerHandler(BuildPlayerOptions options)
    {
        Popup();

        BuildPlayerWindow.DefaultBuildMethods.BuildPlayer(options);
    }

    public static void Popup()
    {
        if (EditorUtility.DisplayDialog(Title, Message, Agree, Disagree))
        {
            AddressableAssetSettings.BuildPlayerContent();
        }
    }
}
