using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Path path;
    public NavMeshAgent Agent { get => agent; }
    private NavMeshAgent agent;

    private StateMachine stateMachine;
    [SerializeField]
    private string currentState; // Debugging only
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = GetComponent<StateMachine>();
        stateMachine.Initialize();
    }

    void Update()
    {
        
    }
}
