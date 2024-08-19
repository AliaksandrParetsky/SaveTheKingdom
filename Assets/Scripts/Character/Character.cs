
public class Character : BaseCharacter
{
    public bool Selected { get; set; }

    public override void OnEnable()
    {
        base.OnEnable();

        Squad.characters.Add(this);
    }

    

    public override void OnDisable()
    {
        base.OnDisable();

        Squad.characters.Remove(this);
    }
}
