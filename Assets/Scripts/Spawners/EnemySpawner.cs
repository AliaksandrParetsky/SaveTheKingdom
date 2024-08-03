using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    private Enemy enemy;

    private void Start()
    {
        CreateEnemyPrefab();
    }

    private void CreateEnemyPrefab()
    {
        var rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        var position = gameObject.transform.position;

        enemy = Instantiate(enemyPrefab, position, rotation);
    }
}
