using System.Collections;
using System.Collections.Generic;
using BoatAttack;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteAlways]
[RequireComponent(typeof(Light))]
public class CloudShadowCookie : MonoBehaviour
{
    public UniversalAdditionalLightData lightData;
    public Vector2 shadowVelocity;
    
    // Update is called once per frame
    void Update()
    {
        if (lightData == null) return;

        var offset = lightData.lightCookieOffset;

        var dir = transform.InverseTransformDirection(GlobalWind.WindVector.x, 0f, GlobalWind.WindVector.y);
        
        offset += new Vector2(dir.x, dir.y) * Time.deltaTime;
        offset.x = Mathf.Repeat(offset.x, lightData.lightCookieSize.x);
        offset.y = Mathf.Repeat(offset.y, lightData.lightCookieSize.y);

        lightData.lightCookieOffset = offset;
    }
}
