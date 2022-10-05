using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatronicMission : MonoBehaviour
{
    // Requirements
    [Header("Mission")]
    [SerializeField] private List<ObjReq> missionObjects = new List<ObjReq>();
    [SerializeField] private string objReqType = "screwdriver";
    [SerializeField] private int amount = 1;
    [System.Serializable] private struct ObjReq
    {
        public string type;
        public int amount;
    }

    [Header("UI")]
    public string message;

    private void Start()
    {
        message = "Need " + amount.ToString() + " " + objReqType + ".";
    }
}
