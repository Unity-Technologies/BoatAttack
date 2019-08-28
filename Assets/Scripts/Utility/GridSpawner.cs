using System.Collections;
using System.Collections.Generic;
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
				Vector3 pos = transform.position + new Vector3(xStep * x, 0f, yStep * -y);
				Instantiate(spawnedObject, pos, transform.rotation, transform);
			}
		}
	}
}
