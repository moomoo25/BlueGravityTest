using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInteractHandle : MonoBehaviour
{
    private InteracableObject interacableObject;
    public GameObject interactButton;
    private Animator buttonAnimator;
    private PlayerInput input = null;
    private void Awake()
    {
        input = new PlayerInput();
        buttonAnimator = interactButton.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Interact.performed += InteractPerformed;
    }
    private void OnDisable()
    {
        input.Disable();
        input.Player.Interact.performed -= InteractPerformed;
    }
    private void InteractPerformed(InputAction.CallbackContext value)
    {
        if (interacableObject != null)
        {
            interacableObject.OnInteract();
            buttonAnimator.SetTrigger("Pressed");
        }
    }
    public void AddInteractObject(InteracableObject ob)
    {
        interacableObject = ob;
        interactButton.SetActive(true);
    }
    public void RemoveInteractObject()
    {
        interacableObject = null;
        interactButton.SetActive(false);
    }

}
