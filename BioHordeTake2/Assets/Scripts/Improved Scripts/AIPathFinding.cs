using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathFinding : MonoBehaviour
{
    
    static public GameObject NearestGO(Vector3 thisPos, string targetType)
    {
        GameObject closestTarget = null;
        GameObject[] allTargets = GameObject.FindGameObjectsWithTag(targetType);

        float distanceToClosestTarget = Mathf.Infinity;
    
        foreach (GameObject currentTarget in allTargets)
        {
            float distanceToTarget = (currentTarget.transform.position - thisPos).sqrMagnitude;
            if (distanceToTarget < distanceToClosestTarget)
            {
                distanceToClosestTarget = distanceToTarget;
                closestTarget = currentTarget;
            }
        }
        if (object.ReferenceEquals(closestTarget, null))
        {
            return GameObject.FindGameObjectWithTag("defaultTarget");
        }
        return closestTarget;
    }
}