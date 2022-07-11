using System.Collections;
using System.Collections.Generic;
using BoatAttack;
using UnityEngine;

[CreateAssetMenu(menuName = "Boat Attack/Boat", fileName = "NewBoat")]
public class BoatDataSO : ScriptableObject
{
    [SerializeReference] public BoatData _data;

    public BoatDataSO()
    {
        _data = new BoatData();
    }
}
