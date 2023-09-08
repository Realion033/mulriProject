using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    public Transform target; // ���� ���(�÷��̾�)�� �����ϱ� ���� public ����
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            // ���� ����� �������� �ʾ��� ���, �⺻������ �÷��̾ �����ϵ��� ����
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            // ���͸� ���� ���(target)���� �̵��ϵ��� ����
            agent.SetDestination(target.position);
        }
    }
}
