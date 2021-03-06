﻿// MoveTo.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NavMeshAgentMoveTo : MonoBehaviour
{

    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
