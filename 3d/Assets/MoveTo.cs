﻿// MoveTo.cs
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent.destination != goal.position) { agent.destination = goal.position; }
    }
}