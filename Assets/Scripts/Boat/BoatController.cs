using UnityEngine;
using System.Collections;

public class BoatController : MonoBehaviour {

	//Boat stats
	public bool Human;
	public int AIdifficulty;

    public Color PrimaryColor;
    public Color TrimColor;
    public Renderer boatRenderer;

	void OnValidate()
	{
        Colourize();
    }

    // Use this for initialization
    void Start ()
	{
        Colourize();
        if (Human == true) 
		{
			gameObject.AddComponent<HumanController>();
		} 
		else 
		{
			gameObject.AddComponent<AIcontroller>();
		}
	}

    void Colourize()
    {
        if (boatRenderer)
        {
            MaterialPropertyBlock mpb = new MaterialPropertyBlock();
            mpb.SetColor("_Color1", PrimaryColor);
            mpb.SetColor("_Color2", TrimColor);
            boatRenderer.SetPropertyBlock(mpb);
        }
    }
}
