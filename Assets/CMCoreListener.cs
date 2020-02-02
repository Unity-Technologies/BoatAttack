using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;


public class CMCoreListener : MonoBehaviour
{

    public CinemachineImpulseListener l1;
    
    public CinemachineImpulseListener l2;

    private bool isHitL1;
    private bool isHitL2;
    
    
    
    private void Update()
    {
        Vector3 soundLocationL1 = Vector3.zero;
        Quaternion rotLocL1 = Quaternion.identity;
        isHitL1 = CinemachineImpulseManager.Instance.GetImpulseAt(l1.transform.position, false,
            l1.m_ChannelMask, out soundLocationL1, out rotLocL1);
        
        Vector3 soundLocationL2 = Vector3.zero;
        Quaternion rotLocL2 = Quaternion.identity;
        isHitL2 = Cinemachine.CinemachineImpulseManager.Instance.GetImpulseAt(l1.transform.position, false,
            l1.m_ChannelMask, out soundLocationL2, out rotLocL2);
        
    }

    private void OnGUI()
    {
        if (gameObject.transform.parent != null && gameObject.transform.parent.name == "Player 4")
        {
            string str = string.Format("Hit1: {0}\nHit2: {1}", isHitL1.ToString(), isHitL2.ToString());
            GUI.TextField(new Rect(0, 0, 100, 100), str);
            
        }
    }
}
