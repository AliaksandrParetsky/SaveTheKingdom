using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    private Enemy enemy;
    private Quaternion rotation;

    private void Awake()
    {
        rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);

        StartCoroutine(CreateEnemyPrefab());
    }

    private IEnumerator CreateEnemyPrefab()
    {
        for(int i = 0; i < 50; i++)
        {
            enemy = Instantiate(enemyPrefab, GetRandomPosition(), rotation);

            yield return new WaitForSeconds(2);
        }
        
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-20.0f, 20.0f), 0.0f, 50.0f);

        return pos;
    }
}
