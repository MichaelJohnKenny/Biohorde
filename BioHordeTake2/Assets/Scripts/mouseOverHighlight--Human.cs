using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseOverHighlight : MonoBehaviour
{
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
}
