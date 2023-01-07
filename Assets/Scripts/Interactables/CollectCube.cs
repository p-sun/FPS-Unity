using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : Interactable
{
    public ParticleSystem particle;
    private Vector3 initPos;

    void Start()
    {
        GetComponent<MeshRenderer>().material.color = Color.cyan;
        initPos = transform.position;
    }

    protected override void Interact()
    {
        Vector3 pos = transform.position;
        pos.y = -10f;
        transform.position = pos;
        particle.Play();
        StartCoroutine(ActivateGameObject());
    }

    IEnumerator ActivateGameObject() {
        yield return new WaitForSeconds(2);
        transform.position = initPos;
    }

}
