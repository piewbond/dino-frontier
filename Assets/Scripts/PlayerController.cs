using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Players target location
    private Vector3 target;

    NavMeshAgent agent;
    Animator animator;

    void Awake() {

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
    }
    void SetAgentPosition() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));

    }
    void SetTargetPosition() {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        

        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            animator.SetBool("isMoving", true);
        }
    }
}
