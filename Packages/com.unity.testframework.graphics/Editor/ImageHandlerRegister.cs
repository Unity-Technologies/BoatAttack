using UnityEditor;
using UnityEditor.Networking.PlayerConnection;

[InitializeOnLoad]
public static class ImageHandlerRegister
{
    static ImageHandlerRegister()
    {
        EditorConnection.instance.Initialize();
        EditorConnection.instance.Register(ImageMessage.MessageId, ImageHandler.instance.HandleImageEvent);

        AssemblyReloadEvents.beforeAssemblyReload += Unregister;
    }

    private static void Unregister()
    {
        EditorConnection.instance.Unregister(ImageMessage.MessageId, ImageHandler.instance.HandleImageEvent);
        AssemblyReloadEvents.beforeAssemblyReload -= Unregister;
    }
}
