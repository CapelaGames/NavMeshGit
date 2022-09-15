using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAnimator : MonoBehaviour
{
    private Animator _anim;
    private NavMeshAgent _agent;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(_agent.velocity.magnitude > 0.1f)
        {
            _anim.SetBool("isWalking", true);
        }
        else
        {
            _anim.SetBool("isWalking", false);
        }
    }
}
