using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AreaMovementModifier : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] float _speed = 10f;
    [SerializeField] float _grassSpeed = 5f;

    [System.Flags]
    public enum myFlags
    {
        Player=0,
        AI =1,
        Objects =2,
        Etc = 4,
        Everything = 0b1111
    }
    public myFlags flags;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        NavMeshHit hit;
        _agent.SamplePathPosition(-1, 0.0f, out hit);

        int GrassMask = 1 << NavMesh.GetAreaFromName("TallGrass");
        int filtered = hit.mask & GrassMask;
        // 0   means we didnt hit the grass
        // !0  means we are on grass
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
