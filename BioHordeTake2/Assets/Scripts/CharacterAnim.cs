using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnim : MonoBehaviour
{

    private Animator anim;
    private NavMeshAgent nmAgent;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        nmAgent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", nmAgent.velocity.magnitude);

    }
}
