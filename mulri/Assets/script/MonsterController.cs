using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private float initialSpeed = 5.0f; // 초기 속도 설정
    public float speedIncrement = 3.0f; // 속도 증가량 설정
    private AudioSource audioSource; // AudioSource 컴포넌트 추가

    // 추가: 오디오 속성
    public float initialPitch = 1.0f; // 초기 음향 피치
    public float pitchDecrease = 0.3f; // 음향 피치 감소량

    private void Start()
    {
        // NavMeshAgent 컴포넌트 가져오기
        navMeshAgent = GetComponent<NavMeshAgent>();

        // AudioSource 컴포넌트 가져오기
        audioSource = GetComponent<AudioSource>();

        // 초기 속도 및 음향 피치 설정
        navMeshAgent.speed = initialSpeed;
        audioSource.pitch = initialPitch;
    }

    // 다른 스크립트에서 호출하여 몬스터 속도 증가 및 음향 피치 감소
    public void IncreaseSpeed()
    {
        // 현재 속도에 증가량을 더하여 속도를 증가시킵니다.
        navMeshAgent.speed += speedIncrement;

        // 음향 피치를 감소시킵니다.
        audioSource.pitch += pitchDecrease;
    }

    // 다른 스크립트에서 호출하여 몬스터 속도 초기화 및 음향 피치 초기화
    public void ResetSpeed()
    {
        // 초기 속도로 재설정합니다.
        navMeshAgent.speed += speedIncrement;

    }
}
