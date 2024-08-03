using UnityEngine;

public class MinionesSpawner : MonoBehaviour
{
    [SerializeField] private Character erikaArcherPrefab;
    [SerializeField] private Character paladinPrefab;
    [SerializeField] private Character crusaderTankPrefab;
    [SerializeField] private Character mariaSwordswomanPrefab;

    private void Awake()
    {
        CreateCharacters();
    }

    private void CreateCharacters()
    {
        var rotation = Quaternion.identity;
        var position = gameObject.transform.position;

        Character erikaArcher = Instantiate(erikaArcherPrefab, position, rotation);

        Character paladin = Instantiate(paladinPrefab, position, rotation);

        Character mariaSwordswoman = Instantiate(mariaSwordswomanPrefab, position, rotation);

        Character crusaderTank = Instantiate(crusaderTankPrefab, position, rotation);
    }
}
