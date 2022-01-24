using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "New LevelData", menuName = "Boat Attack/Level Data", order = 8)]
public class LevelData : ScriptableObject
{
    public string levelName;
    public string description;
    public Sprite UIImage;
    public Texture2D loadingImage;
    public AssetReference masterScene;
    public AssetReference[] supportScenes;
    public bool available;
}
