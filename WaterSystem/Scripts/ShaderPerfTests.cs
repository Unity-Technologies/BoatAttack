using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderPerfTests : MonoBehaviour {

	public Material mat;

	public void ToggleVert(bool toggle)
	{
		string key = "_PERF_VERT";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}

	public void ToggleRef(bool toggle)
	{
		string key = "_PERF_REF";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}

	public void ToggleCol(bool toggle)
	{
		string key = "_PERF_COL";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}
	public void ToggleDepth(bool toggle)
	{
		string key = "_PERF_DEPTH";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}
	public void ToggleLight(bool toggle)
	{
		string key = "_PERF_LIGHTING";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}
	public void ToggleFresnel(bool toggle)
	{
		string key = "_PERF_FRESNEL";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}
	public void ToggleGerstner(bool toggle)
	{
		string key = "_PERF_GERSTNER";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}
	public void ToggleFoam(bool toggle)
	{
		string key = "_PERF_FOAM";
		if(toggle)
			mat.EnableKeyword(key);
		else
			mat.DisableKeyword(key);
	}

}
