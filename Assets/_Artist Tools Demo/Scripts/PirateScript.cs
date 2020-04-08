using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateScript : MonoBehaviour
{
	public void Sink()
	{
		GetComponent<Animator>().SetTrigger("Sink");
	}
}
