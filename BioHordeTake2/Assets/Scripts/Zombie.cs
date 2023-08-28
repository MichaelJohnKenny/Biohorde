using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Zombie : MonoBehaviour
{
    public GameObject SpawnEffect;
    public float attackRange = 2f;
    public float lookAtRange = 12f;
    public int attackDamage=5;
    public float attackCooldown = 0.1f;
    private float attackCooldownTime = 1.1f;
    private float rotationSpeed = 2f;
    GameObject closestHuman = null;
    float distanceToNearestHuman = Mathf.Infinity;
    public GameObject HumanPreFab;
    private ScreenShake cameraShake;
    private Health zombieHealth;
    private Quaternion desiredRotation;
    private Vector3 towardNearest;

    private void Awake()
    {
        cameraShake = GameObject.FindObjectOfType<ScreenShake>() as ScreenShake;
    }

    void Attack(GameObject closestHuman)
    {
        //Debug.Log("attack");
        closestHuman.GetComponent<Health>().Damage(attackDamage);
        attackCooldownTime = 0f;
        cameraShake.Shake(.13f, 1f, true);
    }

    // Start is called before the first frame update
    void Start() 
    {
        //cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ScreenShake>();
        
        zombieHealth = this.GetComponent<Health>();
        Instantiate(SpawnEffect, this.transform.position, this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        attackCooldownTime += Time.deltaTime;
        //Below declaration should be done at runtime then updated as things changee not recreated everyframe.
        closestHuman = AIPathFinding.NearestGO(transform.position, "Human");
        distanceToNearestHuman = (this.transform.position - closestHuman.transform.position).magnitude;

        if (distanceToNearestHuman < lookAtRange)
        {
            towardNearest = (closestHuman.transform.position - this.transform.position).normalized;
            desiredRotation = Quaternion.LookRotation(towardNearest);

            this.transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
        }

        if (distanceToNearestHuman<=attackRange && attackCooldownTime>=attackCooldown)
        {
            Attack(closestHuman);
        }
    }
}