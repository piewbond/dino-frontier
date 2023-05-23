using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NPCInteractable : MonoBehaviour
{

    [SerializeField]
    private UnityEvent interactEvent;
    public void Interact() {
        interactEvent.Invoke();
        Debug.Log("Interact" + this.name);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //setting the interactable
        GameObject.Find("Player").GetComponent<PlayerInteract>().SetInteractable(this);
    }
    public void OnTriggerStay(Collider collision)
    {
        //setting the interactable
        GameObject.Find("Player").GetComponent<PlayerInteract>().SetInteractable(this);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        GameObject.Find("Player").GetComponent<PlayerInteract>().SetInteractable(null);
    }
}
