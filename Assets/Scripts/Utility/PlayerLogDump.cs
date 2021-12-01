using UnityEngine;
using TMPro;

public class PlayerLogDump : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    private void OnEnable()
    {
        Application.logMessageReceived += ApplicationOnlogMessageReceived;
    }
    
    private void OnDisable()
    {
        tmp.text = "";
        Application.logMessageReceived -= ApplicationOnlogMessageReceived;
    }
    
    private void ApplicationOnlogMessageReceived(string condition, string stacktrace, LogType type)
    {
        if (!tmp) return;
        
        string colorTag;
            
        switch (type)
        {
            case LogType.Error:
                colorTag = "red";
                break;
            case LogType.Assert:
                colorTag = "orange";
                break;
            case LogType.Warning:
                colorTag = "yellow";
                break;
            case LogType.Exception:
                colorTag = "red";
                break;
            default:
                colorTag = "white";
                break;
        }
        tmp.text += $"<color={colorTag}>{condition}\n";
    }
}
