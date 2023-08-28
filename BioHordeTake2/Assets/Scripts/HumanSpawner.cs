using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HumanSpawner : MonoBehaviour{

    public float spawnChance=0.9f;
    public GameObject humanPrefab;
    public GameObject HumanConversationPrefab;

    // When the level loads
    void Awake()
    {
        //Loop through all the spawning cubes in the level,
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //if a human will spawn at a cube
            if (UnityEngine.Random.value <= spawnChance)
            {
                Vector3 spawnerLoc = this.transform.GetChild(i).position;
                float rot = UnityEngine.Random.Range(0, 360);
                Quaternion rotq = Quaternion.Euler(0, rot, 0);

                Instantiate(humanPrefab, spawnerLoc, rotq);
                Destroy(this.transform.GetChild(i).gameObject);
            }else
            {
                Destroy(this.transform.GetChild(i).gameObject);
            }

        }
    }
}