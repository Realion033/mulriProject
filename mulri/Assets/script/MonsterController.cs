using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private float initialSpeed = 5.0f; // �ʱ� �ӵ� ����
    public float speedIncrement = 3.0f; // �ӵ� ������ ����
    private AudioSource audioSource; // AudioSource ������Ʈ �߰�

    // �߰�: ����� �Ӽ�
    public float initialPitch = 1.0f; // �ʱ� ���� ��ġ
    public float pitchDecrease = 0.3f; // ���� ��ġ ���ҷ�

    private void Start()
    {
        // NavMeshAgent ������Ʈ ��������
        navMeshAgent = GetComponent<NavMeshAgent>();

        // AudioSource ������Ʈ ��������
        audioSource = GetComponent<AudioSource>();

        // �ʱ� �ӵ� �� ���� ��ġ ����
        navMeshAgent.speed = initialSpeed;
        audioSource.pitch = initialPitch;
    }

    // �ٸ� ��ũ��Ʈ���� ȣ���Ͽ� ���� �ӵ� ���� �� ���� ��ġ ����
    public void IncreaseSpeed()
    {
        // ���� �ӵ��� �������� ���Ͽ� �ӵ��� ������ŵ�ϴ�.
        navMeshAgent.speed += speedIncrement;

        // ���� ��ġ�� ���ҽ�ŵ�ϴ�.
        audioSource.pitch += pitchDecrease;
    }

    // �ٸ� ��ũ��Ʈ���� ȣ���Ͽ� ���� �ӵ� �ʱ�ȭ �� ���� ��ġ �ʱ�ȭ
    public void ResetSpeed()
    {
        // �ʱ� �ӵ��� �缳���մϴ�.
        navMeshAgent.speed += speedIncrement;

    }
}
