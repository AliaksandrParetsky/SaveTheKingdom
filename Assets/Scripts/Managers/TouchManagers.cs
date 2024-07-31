using UnityEngine;

public class TouchManagers : Singleton<TouchManagers>
{
    private InputManager inputManager;
    private Camera cameraMain;
    private Character selectedCharacter;

    private MovementComponent movementComponent;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        cameraMain = Camera.main;

        inputManager.onTouchEvent += Touch;
    }

    private void Touch(Vector2 screenTouchPosition)
    {
        Ray ray = cameraMain.ScreenPointToRay(screenTouchPosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if (hitInfo.transform.TryGetComponent<Character>(out var currentCharacter))
            {
                CharacterSelected(currentCharacter);

                return;
            }

            if (selectedCharacter != null && selectedCharacter.Selected)
            {
                if (selectedCharacter.TryGetComponent<IMovable>(out var movable))
                {
                    movable.Move(hitInfo.point);
                }
            }
        }
    }

    private void CharacterSelected(Character character)
    {
        character.Selected = true;

        selectedCharacter = character;

        print(character.ToString());

        SetFalseSelectedCharacter(character);
    }

    private void SetFalseSelectedCharacter(Character selectedCharcter)
    {
        foreach (Character personage in Squad.characters)
        {
            if (personage != selectedCharcter)
            {
                personage.Selected = false;
            }
        }
    }

    private void OnDisable()
    {
        inputManager.onTouchEvent -= Touch;
    }
}
