using UnityEngine;

public class Character : BaseCharacter
{
    public bool Selected { get; set; }

    private void OnEnable()
    {
        Squad.characters.Add(this);
    }

    private void OnDisable()
    {
        Squad.characters.Remove(this);
    }
}
