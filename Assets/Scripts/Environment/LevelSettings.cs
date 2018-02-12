using UnityEngine;
using System.Collections;

public class LevelSettings : MonoBehaviour {

	public static float waveRoughness;

	public float waveHeight;

	// Use this for initialization
	void Awake () {
		waveRoughness = waveHeight;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
