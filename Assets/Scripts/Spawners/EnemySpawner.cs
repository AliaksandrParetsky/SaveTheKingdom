using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEnemySpawn
{
    [SerializeField] private Enemy enemyZombyPrefab;
    [SerializeField] private Enemy enemyZomby_2Prefab;
    [SerializeField] private Enemy enemyZomby_3Prefab;

    [SerializeField] private int amountEnemiesFirstWave;
    [SerializeField] private int amountEnemiesSecondWave;
    [SerializeField] private int amountEnemiesThirdWave;

    private Quaternion rotation;

    private float minRangeX = -20.0f;
    private float maxRangeX = 20.0f;
    private float startPositionZ = 50.0f;

    private void Awake()
    {
        rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos = new Vector3(Random.Range(minRangeX, maxRangeX), 0.0f, startPositionZ);

        return pos;
    }

    private IEnumerator CreateWave()
    {
        for(int wave = 1; wave <= 3; wave++)
        {
            for (int i = 0; i < amountEnemiesFirstWave && wave == 1; i++)
            {
                Instantiate(enemyZombyPrefab, GetRandomPosition(), rotation);

                yield return new WaitForSeconds(2);
            }

            for (int i = 0; i < amountEnemiesFirstWave && wave == 2; i++)
            {
                Instantiate(enemyZombyPrefab, GetRandomPosition(), rotation);
                Instantiate(enemyZomby_2Prefab, GetRandomPosition(), rotation);

                yield return new WaitForSeconds(3);
            }

            for (int i = 0; i < amountEnemiesFirstWave && wave == 3; i++)
            {
                Instantiate(enemyZombyPrefab, GetRandomPosition(), rotation);
                Instantiate(enemyZomby_2Prefab, GetRandomPosition(), rotation);
                Instantiate(enemyZomby_3Prefab, GetRandomPosition(), rotation);

                yield return new WaitForSeconds(4);
            }

            yield return new WaitForSeconds(60);
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(CreateWave());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }
}
