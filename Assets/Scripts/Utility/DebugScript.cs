using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    private ParticleSystem[] parts;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        parts = FindObjectsOfType<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        int partCountTotal = 0;
        foreach (var ps in parts)
        {
            partCountTotal += ps.particleCount;
        }

        var output = $"Total particles in {parts.Length} systems:{partCountTotal:N}";
        if (!text)
        {
            Debug.LogError(output);
        }
        else
        {
            text.text = output;
        }
    }
}
