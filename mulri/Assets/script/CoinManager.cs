using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab; // Ż�� ���� ������
    public Transform[] coinSpawnPoints; // Ż�� ������ ������ ����Ʈ �迭
    public int numberOfCoinsToSpawn = 5; // ������ Ż�� ������ ��

    void Start()
    {
        if (coinPrefab == null || coinSpawnPoints.Length == 0)
        {
            Debug.LogError("Ż�� ���� ������ �Ǵ� ���� ����Ʈ�� �������� �ʾҽ��ϴ�.");
            return;
        }

        SpawnCoins();
    }

    void SpawnCoins()
    {
        // �������� ���õ� ����Ʈ�� Ż�� ������ �����մϴ�.
        int numCoinsSpawned = 0;
        while (numCoinsSpawned < numberOfCoinsToSpawn)
        {
            int randomIndex = Random.Range(0, coinSpawnPoints.Length);
            Transform spawnPoint = coinSpawnPoints[randomIndex];

            // �ش� ����Ʈ�� �̹� Ż�� ������ �ִ��� Ȯ���ϰ�, ������ �����մϴ�.
            if (spawnPoint.childCount == 0)
            {
                Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
                numCoinsSpawned++;
            }
        }
    }
}
