using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DevControls : MonoBehaviour
{
    public Boolean DevContEnabled = false;
    public Text devText;
    public GameObject ZombiePrefab;
    //public TextMeshPro ZombieSelected;
    public GameObject HumanPreFab;
    //public TextMeshPro HumanSelected;
    public GameObject SecurityPreFab;
    //public TextMeshPro SecuritySelected;
    private int currentActiveDebug = 1;

    private void Awake()
    {  
        devText.enabled = DevContEnabled;
    }

    void Update()
    {
        if (Input.GetKeyDown("/")) 
        { 
            currentActiveDebug = 1; 
            DevContEnabled = !DevContEnabled;
            devText.enabled= !devText.enabled;
        }
        
        if (DevContEnabled == true){
            if (Input.GetKeyDown("1")) 
            { 
                currentActiveDebug = 1;
                devText.text = "Debug: on /n Zombie";
            }
            if (Input.GetKeyDown("2"))
            {
                currentActiveDebug = 2;
                devText.text = "Debug: on /n Human";
            }
            if (Input.GetKeyDown("3"))
            {
                currentActiveDebug = 3;
                devText.text = "Debug: on /n Security";
            }
            if (Input.GetMouseButtonDown(0)) 
            {
                GameObject currentSpawnObj = ZombiePrefab;
                Vector3 mouse = Input.mousePosition;//Get the mouse Position
                Ray castPoint = Camera.main.ScreenPointToRay(mouse);//Cast a ray to get where the mouse is pointing at
                RaycastHit hit;//Stores the position where the ray hit.
                switch (currentActiveDebug)
                {
                    case (1):
                        currentSpawnObj = ZombiePrefab;
                        break;
                    case (2):
                        currentSpawnObj = HumanPreFab;
                        break;
                    case (3):
                        currentSpawnObj = SecurityPreFab;
                        break;
                }
                if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))//If the raycast doesnt hit a wall
                {
                    Instantiate(currentSpawnObj, hit.point, Quaternion.Euler(0, 0, 0));
                }
            }
        }
    }
}
