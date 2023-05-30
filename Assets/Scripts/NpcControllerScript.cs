using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcControllerScript : MonoBehaviour
{
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Start()
    {
   
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTo(Vector3 pos, Action onArrivedAtPosition = null) { 
        agent.SetDestination(pos);
        if (onArrivedAtPosition != null) { 
            onArrivedAtPosition.Invoke();
        }
    }
}
