using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatFoamGenerator : MonoBehaviour
{
    public Transform boatTransform;
    private ParticleSystem.MainModule module;
    public ParticleSystem ps;
    public float waterLevel = 0;
    private Vector3 offset;

    private void Start()
    {
        module = ps.main;
        offset = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = boatTransform.TransformPoint(offset);
        pos.y = waterLevel;
        transform.position = pos;

        var fwd = boatTransform.forward;
        fwd.y = 0;
        var angle = Vector3.Angle(fwd.normalized, Vector3.forward);
        module.startRotation = angle * Mathf.Deg2Rad;
    }
}
