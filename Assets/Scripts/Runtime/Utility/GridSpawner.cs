using UnityEngine;

public class GridSpawner : MonoBehaviour
{
	public GameObject spawnedObject;
	public float xStep = 3f;
	public float yStep = 8f;
	public int columns = 3;
	public int rows = 3;

	private void Start()
	{
		if (spawnedObject == null)
			return;

		for (int x = 0; x < columns; x++)
		{
			for (int y = 0; y < rows; y++)
			{
				var t = transform;
				var pos = t.position + new Vector3(xStep * x, 0f, yStep * -y);
				Instantiate(spawnedObject, pos, t.rotation, t);
			}
		}
	}
}
