using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float attackDistance;
    private NavMeshAgent m_Agent;
    private float m_Distance;
    public GameObject loseScreen;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        m_Distance = Vector3.Distance(m_Agent.transform.position, target.position);
        if (m_Distance < attackDistance)
        {
            m_Agent.isStopped = true;
            loseScreen.SetActive(true);
        }
        else
        {
            m_Agent.isStopped = false;
            m_Agent.destination = target.position;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            //gameObject.SetObjectColor(Color.red);
            Destroy(gameObject);
        }
    }
}
