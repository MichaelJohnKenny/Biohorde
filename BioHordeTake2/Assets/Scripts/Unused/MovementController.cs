﻿using System.Collections; using System.Collections.Generic; using UnityEngine;  public class MovementController : MonoBehaviour {      public CharacterController charcont;     public float movespeed = 10f;      private float x;     private float z;     private Vector3 move;      // Update is called once per frame     void Update()     {         //Forward         x = Input.GetAxis("Vertical");         //Side         z = Input.GetAxis("Horizontal");          charcont.SimpleMove(x*movespeed*2*this.transform.forward);         charcont.SimpleMove(z*movespeed*this.transform.right);     } } 