using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;


    RectTransform containerRect;

    void Start()
    {
        containerRect = containerGameObject.GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (playerInteract.GetInteractable() != null) {
            Show();
            SetPosition();
        } else
        {
            Hide();
        }
    }


    private void Show() {
        SetPosition();
        containerGameObject.SetActive(true);
        
    }
    private void SetPosition() {
        Vector3 pos = playerInteract.GetInteractable().transform.position;
        containerRect.anchoredPosition3D = new Vector3(pos.x, pos.y - 0.1f, 1.0f);
    }
    public void Hide() { containerGameObject.SetActive(false); }
}
