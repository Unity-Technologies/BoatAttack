using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Console = BoatAttack.Console;

public class FreeCam : MonoBehaviour
{
    public static FreeCam Instance;
    [NonSerialized] public bool active = false;
    public CinemachineVirtualCameraBase cam;
    
    [Header("Movement")]
    public float speed = 2f;
    private float speedMulti = 1f;
    private float vel;
    public float accelleration = 25.0f;

    [Header("Look")] 
    public Vector2 sensitivity = new Vector2(100f, 50f);

    public bool invertY = false;
    
    private Vector2 flyVect;
    private Vector2 lookVect;

    private void OnEnable()
    {
        Instance = this;
    }

    public void OnFly(InputAction.CallbackContext context)
    {
        if (!active) return;
        
        var vect = context.ReadValue<Vector2>();
        flyVect = vect;
        if (context.canceled)
        {
            speedMulti = 1f;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        if (!active) return;
        
        var vect = context.ReadValue<Vector2>();
        lookVect = vect;
    }

    private void LateUpdate()
    {
        if (!active) return;
        // Fly
        var pos = transform.position;
        speedMulti = Mathf.SmoothDamp(speedMulti, 100f, ref vel, accelleration);
        var realSpeed = speed * speedMulti * Time.deltaTime;
        pos += transform.forward * flyVect.y * realSpeed;
        pos += transform.right * flyVect.x * realSpeed;
        
        // Move
        var rot = transform.localEulerAngles;
        var lookSpeed = Time.deltaTime;
        rot.x += (invertY ? lookVect.y : -lookVect.y) * sensitivity.y * lookSpeed;
        rot.y += lookVect.x * sensitivity.x * lookSpeed;

        transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));

        var fwd = transform.forward;
        fwd.y = Mathf.Clamp(fwd.y, -0.8f, 0.8f );
        transform.forward = fwd;
    }
    
    [Console.ConsoleCmd]
    public static void NoClipOn()
    {
        Instance.cam.Priority = 9999;
        Instance.active = true;
    }
    
    [Console.ConsoleCmd]
    public static void NoClipOff()
    {
        Instance.cam.Priority = -9999;
        Instance.active = false;
    }
}
