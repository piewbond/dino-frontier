using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public void Interact() {

        Debug.Log("Interact" + this.name);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("In range");
    }
}
