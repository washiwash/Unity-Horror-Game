using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StalkerAi : MonoBehaviour
{
    public GameObject stalkerDest;
    UnityEngine.AI.NavMeshAgent stalkerAgent;
    void Start()
    {
        stalkerAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    
    void Update()
    {
        stalkerAgent.SetDestination(stalkerDest.transform.position); 
    }
}
