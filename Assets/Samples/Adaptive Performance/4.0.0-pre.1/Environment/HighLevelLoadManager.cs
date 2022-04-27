using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLevelLoadManager : MonoBehaviour
{
    [Tooltip("How many islands in percent(%) to enable spinning at the start of the test")]
    [Range(0, 100)]
    public float startingLoadAmount = 100;

    [Tooltip("Rows and cols for the grid")]
    public Vector3 islandGrid;

    private float spawnAmount = 0;
    public GameObject prefab;
    public Transform floatingRocksParent;

    public void SetLoad(float loadAmount)
    {
        startingLoadAmount = loadAmount;
        int childCount = floatingRocksParent.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Destroy(floatingRocksParent.GetChild(i).gameObject);
        }

        spawnAmount = islandGrid.x * islandGrid.y * islandGrid.z;
        spawnAmount = spawnAmount / 100.0f * loadAmount;

        var meshRenderer = prefab.GetComponentsInChildren<MeshRenderer>()[0];
        var bounds = meshRenderer.bounds.size + Vector3.one;
        var minX = bounds.x / 2 * islandGrid.x;
        var minZ = bounds.z / 2 * islandGrid.z;

        for (var layer = 1; layer <= islandGrid.z; layer++)
        {
            for (var row = 1; row <= islandGrid.y; row++)
            {
                for (var col = 1; col <= islandGrid.x; col++)
                {
                    var objectPos = new Vector3((col - 1) * bounds.x, (layer - 1) * bounds.y, (row - 1) * bounds.z);
                    objectPos.x -= minX;
                    objectPos.z -= minZ;
                    if (spawnAmount > 0)
                    {
                        Instantiate(prefab, objectPos, Quaternion.identity, floatingRocksParent);
                        spawnAmount--;
                    }
                }
            }
        }
    }
}
