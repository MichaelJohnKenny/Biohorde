using System.Collections;using System.Collections.Generic;using UnityEngine;using UnityEngine.AI;
public class ZombieAiMovement : MonoBehaviour{    
    private NavMeshAgent nmAgent;
    private Vector3 screenMousePos;
    private Vector3 offset;
    bool chasing = false;
    public GameObject zombieMovementTarget;

    private void Start()
    {
        nmAgent = this.GetComponent<NavMeshAgent>();
        offset = new Vector3(0.2f,0,0.2f);

        zombieMovementTarget = GameObject.Find("ZombieMovementTarget");
        nmAgent.SetDestination(zombieMovementTarget.transform.position - offset);
    }    

    void Update()
    {
        if (nmAgent.remainingDistance <= .1f) 
        {
            nmAgent.isStopped = true;
        }

        if (Input.GetMouseButton(0) && nmAgent.isStopped)
        {
            nmAgent.isStopped = false;
        }

        nmAgent.SetDestination(zombieMovementTarget.transform.position-offset);       
    }
}