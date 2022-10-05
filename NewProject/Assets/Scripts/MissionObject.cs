using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionObject : MonoBehaviour
{
    [Header("Attributes")]
    public string objectType;
    public int reqAmount;

    public MissionObject(string _objectType, int _reqAmount)
    {
        objectType = _objectType;
        reqAmount = _reqAmount;
    }
}
