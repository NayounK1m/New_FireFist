using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

//NPC 네비게이트 자동 움직임 로직
public class NPCCtrl_Move : MonoBehaviour
{
    [SerializeField]
    Transform[] PatrolPath = null;

    private NavMeshAgent NMA = null;
    private Animator anim = null;
    private Rigidbody rigid = null;
    private int m_Count = 0;

    private void OnTriggerEnter(Collider other)
    {
        anim.SetBool("isWalk", false);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        NMA = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        NMA.speed = 1.0f;
        InvokeRepeating("MoveToNextWayPoint", 1.0f, 1.0f);
    }
    private void Update()
    {
        InvokeRepeating("MoveToNextWayPoint", 1.0f, 1.0f);
    }

    private void FixedUpdate()
    {
        FreezeVelocity();
    }

    void FreezeVelocity()
    {
        rigid.velocity = Vector3.zero;
        rigid.angularVelocity = Vector3.zero;
    }

    void MoveToNextWayPoint()
    {
        if (NMA.velocity == Vector3.zero)
        {
            NMA.SetDestination(PatrolPath[m_Count++].position);
            anim.SetBool("isWalk", true);

            if (m_Count >= PatrolPath.Length -1)
                m_Count = 0;
        }
    }
}
