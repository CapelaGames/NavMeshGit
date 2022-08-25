using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToObject : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private  NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (_target != null)
        {
            _agent.destination = _target.position;
        }
    }
}
