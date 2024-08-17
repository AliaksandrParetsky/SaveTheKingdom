using System.Collections.Generic;
using UnityEngine;

public class MinionesSpawner : MonoBehaviour
{
    [SerializeField] List<Character> charactersPrefabs = new List<Character>();

    private void Awake()
    {
        CreateCharacters();
    }

    private void CreateCharacters()
    {
        var rotation = Quaternion.identity;

        foreach (var character in charactersPrefabs)
        {
            Instantiate(character, GetRandomPosition(), rotation);
        }
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 pos = new Vector3(Random.Range(-10.0f, 10.0f), 0.0f, Random.Range(-45.0f, -40.0f));

        return pos;
    }
}
