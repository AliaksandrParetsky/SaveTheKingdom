using System;
using UnityEngine;

public class TouchManagers : Singleton<TouchManagers>
{
    private InputManager inputManager;
    private Camera cameraMain;
    private Character selectedCharacter;
    private Vector3 touchPosition;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnTouchEvent += Touch;
    }

    private void Touch(Vector2 screenTouchPosition)
    {
        cameraMain = Camera.main;

        Ray ray = cameraMain.ScreenPointToRay(screenTouchPosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            if (hitInfo.transform.TryGetComponent<Character>(out var currentCharacter))
            {
                CharacterSelected(currentCharacter);

                return;
            }
            if(hitInfo.transform.TryGetComponent<Enemy>(out var currentEnemy))
            {
                if(selectedCharacter == null)
                {
                    print($"{currentEnemy.name}");
                }

                Health targetEnemy = currentEnemy.GetComponent<Health>();

                MoveToTarget(targetEnemy);

                return;
            }

            MoveToPoint(hitInfo.point);

            CharacterSelectionReset();
        }
    }

    private void MoveToTarget(Health target)
    {
        if (selectedCharacter != null && selectedCharacter.Selected)
        {
            if (selectedCharacter.TryGetComponent<IMovable>(out var movable))
            {
                movable.MoveToEnemy(target);
            }
        }
    }

    private void MoveToPoint(Vector3 point)
    {
        if (selectedCharacter != null && selectedCharacter.Selected)
        {
            if (selectedCharacter.TryGetComponent<IMovable>(out var movable))
            {
                movable.Move(point);
            }
        }
    }

    private void CharacterSelected(Character character)
    {
        character.Selected = true;

        selectedCharacter = character;

        SetFalseSelectedCharacters(character);
    }

    private void CharacterSelectionReset()
    {
        foreach (Character personage in Squad.characters)
        {
            personage.Selected = false;
        }
    }

    private void SetFalseSelectedCharacters(Character selectedCharcter)
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
        inputManager.OnTouchEvent -= Touch;
    }
}
