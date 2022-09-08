using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AreaMovementModifier : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] float _speed = 10f;
    [SerializeField] float _grassSpeed = 2.5f;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        NavMeshHit hit;
        _agent.SamplePathPosition(-1, 0.0f, out hit);

        int grassMask = 1 << NavMesh.GetAreaFromName("TallGrass");

        //& - and
        //| - or
        //^ - xor

        int filtered = hit.mask & grassMask;
        //0  means we didn't hit the grass
        //!0 means we are on the grass

        if(filtered == 0)
        {
            _agent.speed = _speed;
        }
        else
        {
            _agent.speed = _grassSpeed;
        }
    }
}
