using System;
using Unity.Cinemachine;
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
    private Transform _transform;
    private void OnEnable()
    {
        Instance = this;
        _transform = transform;
        DontDestroyOnLoad(gameObject);
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
        var pos = _transform.position;
        speedMulti = Mathf.SmoothDamp(speedMulti, 100f, ref vel, accelleration);
        var realSpeed = speed * speedMulti * Time.unscaledDeltaTime;
        pos += _transform.forward * flyVect.y * realSpeed;
        pos += _transform.right * flyVect.x * realSpeed;
        
        // Move
        var rot = _transform.localEulerAngles;
        var lookSpeed = Time.unscaledDeltaTime;
        rot.x += (invertY ? lookVect.y : -lookVect.y) * sensitivity.y * lookSpeed;
        rot.y += lookVect.x * sensitivity.x * lookSpeed;

        _transform.SetPositionAndRotation(pos, Quaternion.Euler(rot));

        var fwd = _transform.forward;
        fwd.y = Mathf.Clamp(fwd.y, -0.8f, 0.8f );
        _transform.forward = fwd;
    }
    
    [Console.ConsoleCmd]
    public static void NoClipOn()
    {
        Instance.cam.Priority.Value = 9999;
        Instance.active = true;
    }
    
    [Console.ConsoleCmd]
    public static void NoClipOff()
    {
        Instance.cam.Priority.Value = -9999;
        Instance.active = false;
    }
}
