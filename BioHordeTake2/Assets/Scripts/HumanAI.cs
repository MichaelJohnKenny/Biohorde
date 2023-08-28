using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAI : MonoBehaviour
{

    private NavMeshAgent nmAgent;
    public float zombieFleeRange = 12f;
    private Vector3 awayfromzomb = new Vector3(0,0,0);
    private GameObject visionArea;
    private GameObject closestZombie;

    public AIPathFinding PathFinding;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = this.GetComponent<NavMeshAgent>();
        nmAgent.isStopped = false;
        //visionArea = this.GetComponentInChildren<HumanViewCube>();
    }

    public Color highlightColor = Color.cyan;
    private Color startcolor;

    void OnMouseEnter()
    {
        startcolor = this.GetComponentInChildren<SkinnedMeshRenderer>().material.color;
        this.GetComponentInChildren<SkinnedMeshRenderer>().material.color = highlightColor;
    }
    void OnMouseExit()
    {
        this.GetComponentInChildren<SkinnedMeshRenderer>().material.color = startcolor;
    }

    // Update is called once per frame
    void Update()
    {
        closestZombie = AIPathFinding.NearestGO(transform.position,"Zombie");
        awayfromzomb = this.transform.position - closestZombie.transform.position;

        if (awayfromzomb.magnitude < zombieFleeRange)
        {
            nmAgent.SetDestination((awayfromzomb.normalized * 10)+this.transform.position);
        }
        //nmAgent.isStopped = false;
    }
}