using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovementTargetMove : MonoBehaviour
{
    Vector3 screenMousePos;
    bool mousePos;
    NavMeshAgent nmAgent;
    LineRenderer line;
    bool isLocked = false;
    GameObject target;
    GameObject lockedTarget;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = this.GetComponent<NavMeshAgent>();
        nmAgent.isStopped=true;
        nmAgent.SetDestination(this.transform.position);
        line = this.GetComponent<LineRenderer>();
    }

    void DrawPath(NavMeshPath path){
        
        line.SetPosition(0, this.transform.position);
        if(path.corners.Length<2){
            line.SetPosition(1,nmAgent.destination);
            return;
        }

        line.positionCount=path.corners.Length;
        for(int i = 1; i<path.corners.Length; i++){
            line.SetPosition(i, path.corners[i]);
        }
    }

    void Update(){
        screenMousePos = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(screenMousePos);
        RaycastHit hit;
        mousePos = Physics.Raycast(castPoint, out hit, Mathf.Infinity);

        //Ensure that the sphere is on the outside of a circle/ellipse made from the averages of the zombies
        //or make it so that the zombies and sphere have the same end point.

        DrawPath(nmAgent.path);
        
        //Moves Zombies to where the mouse clicked.
        if (Input.GetMouseButton(0))          
        {
            line.startColor = new Color(0,51,2);
            line.endColor = new Color(0, 96, 4);

            //Set zombie target location to where mouse clicked.
            nmAgent.SetDestination(hit.point);
            isLocked = false;
            target = hit.collider.gameObject;

            //If the target is a Human
            if (target.tag.Equals("Human"))
            {
                isLocked = true;
                lockedTarget = hit.collider.gameObject;
            }
            
            nmAgent.isStopped=false;
        }

        if (isLocked)
        {
            if (lockedTarget.transform == null)
            {
                UnlockTarget();
            }
            nmAgent.SetDestination(lockedTarget.transform.position);
        }
    }

    public void UnlockTarget()
    {
        nmAgent.SetDestination(this.transform.position);
        nmAgent.isStopped = true;
        isLocked = false;
    }
}
