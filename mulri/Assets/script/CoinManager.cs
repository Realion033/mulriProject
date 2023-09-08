using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject coinPrefab; // 탈출 코인 프리팹
    public Transform[] coinSpawnPoints; // 탈출 코인이 생성될 포인트 배열
    public int numberOfCoinsToSpawn = 5; // 생성할 탈출 코인의 수

    void Start()
    {
        if (coinPrefab == null || coinSpawnPoints.Length == 0)
        {
            Debug.LogError("탈출 코인 프리팹 또는 생성 포인트가 설정되지 않았습니다.");
            return;
        }

        SpawnCoins();
    }

    void SpawnCoins()
    {
        // 무작위로 선택된 포인트에 탈출 코인을 생성합니다.
        int numCoinsSpawned = 0;
        while (numCoinsSpawned < numberOfCoinsToSpawn)
        {
            int randomIndex = Random.Range(0, coinSpawnPoints.Length);
            Transform spawnPoint = coinSpawnPoints[randomIndex];

            // 해당 포인트에 이미 탈출 코인이 있는지 확인하고, 없으면 생성합니다.
            if (spawnPoint.childCount == 0)
            {
                Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
                numCoinsSpawned++;
            }
        }
    }
}
