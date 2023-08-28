using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Deprecated
public class Human : MonoBehaviour
{ 
    public Human[] Humans;
    public Zombie ZombiePreFab;
    public int hp = 10; 
    private NavMeshAgent nmAgent;
    public float zombieAttackRange = 10f;
    private Vector3 awayfromzomb;
    private GameObject visionArea;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = this.GetComponent<NavMeshAgent>();
        //visionArea = this.GetComponentInChildren<HumanViewCube>();
        //GameObject humanView = this.compn;
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
        float distanceToClosestZombie = Mathf.Infinity;
        Zombie closestZombie = null;
        Zombie[] allZombies = GameObject.FindObjectsOfType<Zombie>();
    
        foreach (Zombie currentZombie in allZombies)
        {
            float distanceToZombie = (currentZombie.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToZombie < distanceToClosestZombie)
            {
                distanceToClosestZombie = distanceToZombie;
                closestZombie = currentZombie;
            }
        }

        awayfromzomb = this.transform.position - closestZombie.transform.position;

        nmAgent.SetDestination(awayfromzomb.normalized * 5);
    }


}
