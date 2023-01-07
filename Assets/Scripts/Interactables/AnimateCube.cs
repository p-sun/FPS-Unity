using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateCube : Interactable
{
    Animator animator;
    private string startPrompt;

     void Start()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0; // Note. This speed is always starts with 1. Not the same as playback speed set in Animator inspector panel.

        startPrompt = promptMessage;

        GetComponent<MeshRenderer>().material.color = Color.yellow;
    }

    void Update()
    {
        promptMessage = isAnimating() ? "Animating..." : startPrompt;
    }

    protected override void Interact()
    {
        animator.speed = isAnimating() ? 0:  1;
    }

    private bool isAnimating()
    {
        return animator.speed > 0;
    }
}
