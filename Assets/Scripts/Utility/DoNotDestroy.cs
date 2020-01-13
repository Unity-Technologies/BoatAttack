using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }
}
