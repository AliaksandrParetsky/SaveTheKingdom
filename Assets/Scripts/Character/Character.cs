using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MovementComponent))]
public class Character : MonoBehaviour
{
    [SerializeField] MovementComponent movementComponent;

    [SerializeField] private static List<Character> characters = new List<Character>();

    private InputManager inputManager;

    private Camera cameraMain;

    private bool selected;

    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        cameraMain = Camera.main;

        inputManager.onTouchEvent += TouchEvent;

        characters.Add(this);
    }

    private void TouchEvent(Vector2 screenPosition)
    {
        Ray ray = cameraMain.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            Character targetCharacter = hitInfo.transform.gameObject.GetComponent<Character>();

            if (targetCharacter is Character)
            {
                SelectedCharacter(targetCharacter);

                return;
            }
                
            if (selected)
            {
                SetMovement(hitInfo);
            }
        }
    }

    private void SetMovement(RaycastHit hitInfo)
    {
        movementComponent.Move(hitInfo.point);
    }

    private void SelectedCharacter(Character character)
    {
        if (character == this)
        {
            character.selected = true;

            print($"Select Character - {character.name}");

            SetFalseSelectedCharacter();
        }
    }

    private void SetFalseSelectedCharacter()
    {
        foreach (Character personage in characters)
        {
            if (personage != this)
            {
                personage.selected = false;
            }
        }
    }

    private void OnDisable()
    {
        inputManager.onTouchEvent -= TouchEvent;

        characters.Remove(this);
    }

}
