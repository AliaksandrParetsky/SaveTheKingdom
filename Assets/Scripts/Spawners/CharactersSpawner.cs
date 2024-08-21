using System;
using System.Collections.Generic;
using UnityEngine;

public class CharactersSpawner : MonoBehaviour, ICharactersSpawn
{
    [SerializeField] List<Character> charactersPrefabs = new List<Character>();

    public void CharactersSpawn()
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
        Vector3 pos = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0.0f, UnityEngine.Random.Range(-45.0f, -40.0f));

        return pos;
    }


}
