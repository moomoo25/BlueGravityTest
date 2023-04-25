using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractCollider : MonoBehaviour
{
    [SerializeField] private PlayerInteractHandle playerInteractHandle;
    private void OnTriggerEnter(Collider other)
    {
        InteracableObject interacableObject = other.GetComponent<InteracableObject>();
        if (interacableObject != null)
        {
            playerInteractHandle.AddInteractObject(interacableObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        InteracableObject interacableObject = other.GetComponent<InteracableObject>();
        if (interacableObject != null)
        {
            playerInteractHandle.RemoveInteractObject();
        }
    }
}
