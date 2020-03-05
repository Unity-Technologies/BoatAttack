using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class GunController : MonoBehaviour
{
    public InputAction fireAction;

    public GameObject gun;

    private PlayableDirector gunDirector;

    // Start is called before the first frame update
    void Start()
    {
        InitGuns();
        
        // Have it run your code when the Action is triggered.
        fireAction.performed += FireGuns;

        // Start listening for control changes.
        fireAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
//        if (Input.GetAxis("fire") > 1)
//        {
//            DeployGuns();
//        }
    }

    void InitGuns()
    {
        gunDirector = gun.GetComponent<PlayableDirector>();
        gunDirector.time = 0f;
        gunDirector.Stop();
        
        Debug.LogFormat("InitGuns {0}", gunDirector.time);
    }

    void DeployGuns()
    {
        gunDirector.Play();
    }

    void FireGuns(InputAction.CallbackContext ctx)
    {
        Debug.Log("FIRE!!!!");
        gunDirector.Play();
    }
}
