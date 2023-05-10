using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {

            Debug.Log("Interact");
            Collider2D collider = GetComponent<Collider2D>();
            if (collider.TryGetComponent(out NPCInteractable nPCInteractable))
            {
                nPCInteractable.Interact();
            }
        }
    }
}
