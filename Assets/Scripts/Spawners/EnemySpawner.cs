using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;

    private Enemy enemy;

    private void Awake()
    {
        CreateEnemyPrefab();
    }

    private void CreateEnemyPrefab()
    {
        var rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        var position = new Vector3();

        enemy = Instantiate(enemyPrefab, position, rotation);
    }
}
