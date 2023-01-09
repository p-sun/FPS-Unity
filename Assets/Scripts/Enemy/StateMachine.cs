using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public PatrolState patrolState = new PatrolState();

    void Start()
    {
        ChangeState(patrolState);
    }

    void Update()
    {
        if (activeState != null )
        {
            activeState.Perform();
        }
    }

    public void Initialize()
    {

    }

    public void ChangeState(BaseState newState)
    {
        if (activeState != null)
        {
            activeState.Exit();
        }

        activeState = newState;
        if (newState != null)
        {
            newState.enemy = GetComponent<Enemy>();
            newState.stateMachine = this;
            newState.Enter();
        }
    }
}
