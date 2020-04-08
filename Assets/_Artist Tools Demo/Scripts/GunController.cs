using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class GunController : MonoBehaviour
{
    public InputAction fireAction;
    public GameObject gun;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    private PlayableDirector gunDirector;

    // Start is called before the first frame update
    void Start()
    {
        InitGuns();
        
        // Have it run your code when the Action is triggered.
        fireAction.performed += DeployGuns;

        // Start listening for control changes.
        fireAction.Enable();
    }

    void InitGuns()
    {
        gunDirector = gun.GetComponent<PlayableDirector>();
        gunDirector.time = 0f;
        gunDirector.Stop();
    }

    void DeployGuns(InputAction.CallbackContext ctx)
    {
        fireAction.performed -= DeployGuns;
        gunDirector.Play();
    }

    public void GunsReady()
    {
        fireAction.performed += FireGuns;
    }

    void FireGuns(InputAction.CallbackContext ctx)
    {
		RaycastHit hit;

		if (Physics.Raycast(transform.position + new Vector3(0, 0, 5), transform.forward, out hit, 100))
		{
			PirateScript p = hit.transform.GetComponent<PirateScript>();
			if (p != null)
				p.Sink();
		}
        ps1.Play();
        ps2.Play();
    }
}
