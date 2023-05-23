using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public NPCInteractable interactable = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (interactable != null) {
                interactable.Interact();
            }
        }
    }
    public void SetInteractable(NPCInteractable interactable) => this.interactable = interactable;

    public NPCInteractable GetInteractable() { 
        return interactable;
    }
    public void ClearInteractable() { 
        interactable = null;
    }
}
