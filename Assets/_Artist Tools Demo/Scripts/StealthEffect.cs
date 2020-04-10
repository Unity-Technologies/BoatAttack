using UnityEngine;

public class StealthEffect : MonoBehaviour
{
	MeshRenderer rend;
	Material mat;
	string propName = "_dissolve";

	int dir = -1;
	float elapsedTime;

	private void Start()
	{
		rend = GetComponent<MeshRenderer>();
		if (rend == null)
			Destroy(this);

		mat = rend.material;
		elapsedTime = 1f;
	}

	void Update()
    {
		if (elapsedTime < 1)
		{
			elapsedTime += Time.deltaTime;
			float val = Mathf.Lerp(dir == 1 ? 0 : 1, dir == 1 ? 1 : 0, elapsedTime);

			mat.SetFloat(propName, val);
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				elapsedTime = 0f;
				dir *= -1;
			}
		}
    }
}
