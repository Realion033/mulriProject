using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour
{
    public Transform target; // 추적 대상(플레이어)을 지정하기 위한 public 변수
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (target == null)
        {
            // 추적 대상을 설정하지 않았을 경우, 기본적으로 플레이어를 추적하도록 설정
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (target != null)
        {
            // 몬스터를 추적 대상(target)으로 이동하도록 설정
            agent.SetDestination(target.position);
        }
    }
}
