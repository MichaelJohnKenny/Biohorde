using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject playercamera;
    public float cameraspeed = 10f;
    public float scrollSens = 5f;
    public Vector3 focalPlane;
    private Vector3 initialMousePosition = new Vector3(0f, 0f, 0f);
    private Vector3 currentMousePosition = new Vector3(0f, 0f, 0f);
    private Vector3 scrolMove = new Vector3(0f, 0f, 0f);
    bool pressedThisFrame = false; //pressed thisframe
    public float mouseSensitivity = 0.05f;
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        Ray castPoint = Camera.main.ScreenPointToRay(this.transform.position);//Cast a ray to get where the mouse is pointing at
        RaycastHit hit;//Stores the position where the ray hit.
        float scroll = 0;

        if (Input.GetMouseButtonDown(2))
        {
            initialMousePosition = Input.mousePosition;
            currentMousePosition = initialMousePosition;
            pressedThisFrame = true;
        }
        else if(Input.GetMouseButton(2) && !pressedThisFrame)
        {
            currentMousePosition = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(2))
        {
            currentMousePosition = initialMousePosition = new Vector3(0f, 0f, 0f);
        }

        //Mouse to move camera out/in.
        scroll = Input.mouseScrollDelta.y;
        if (scroll!=0)
        {
            Vector3 scrolMove = playercamera.transform.forward.normalized * scroll * scrollSens;
            playercamera.transform.position += scrolMove;
        }

        Vector3 mouseMove = new Vector3(mouseSensitivity * (initialMousePosition.x - currentMousePosition.x), 0f, mouseSensitivity * (initialMousePosition.y - currentMousePosition.y));



        Vector3 move = new Vector3(Input.GetAxis("Horizontal")*3, 0f, Input.GetAxis("Vertical")*3);//Keyboard camera movement

        playercamera.transform.position += mouseMove;
        
        playercamera.transform.position += scrolMove;

        playercamera.transform.position += move * Time.deltaTime * cameraspeed; //kb camera movement

        initialMousePosition = currentMousePosition;
        currentMousePosition = new Vector3(0f,0f,0f);
        pressedThisFrame = false;
        Ray focalPlane = Camera.main.ScreenPointToRay(Camera.main.transform.forward);
        RaycastHit focalHit;
        
    }
}
