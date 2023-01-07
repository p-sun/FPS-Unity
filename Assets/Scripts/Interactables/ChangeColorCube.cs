using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCube : Interactable
{
    MeshRenderer meshRend;
    public Color[] colors;
    private int colorIndex;

    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        meshRend.material.color = Color.red;
    }

    protected override void Interact()
    {
        base.Interact();

        colorIndex = (colorIndex + 1) % colors.Length;
        meshRend.material.color = colors[colorIndex];
    }
}
