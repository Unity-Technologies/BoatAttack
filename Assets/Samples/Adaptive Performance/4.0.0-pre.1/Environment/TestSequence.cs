using System.Collections.Generic;
using UnityEngine;

public class TestSequence : MonoBehaviour
{
    public bool autoMode = false;
    public bool loop = false;
    public int loopCycles = 1;
    public List<LoadLevel> orderedLoadLevels = new List<LoadLevel>
    {
        new LoadLevel(LoadLevel.loadlevels.High, 30),
        new LoadLevel(LoadLevel.loadlevels.Mid, 20)
    };
}
