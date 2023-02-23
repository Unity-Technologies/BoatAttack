using UnityEngine;
using UnityEngine.Video;

public class MenuVideo : MonoBehaviour
{
    private bool blurred;

    public VideoPlayer video;
    
    private void OnEnable()
    {
        video.targetCamera = Camera.main;
    }

    public void ToggleBlurred()
    {
        blurred = !blurred;
        KawaseBlur.KawasePass.Enabled = blurred;
    }
    
    public void SetBlurred(bool enabled)
    {
        blurred = enabled;
        KawaseBlur.KawasePass.Enabled = enabled;
    }
}
