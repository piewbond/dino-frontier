
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameHandler : MonoBehaviour
{
    private bool locked = true;

    public CameraFollow cameraFollow;
    public Transform playerTransform;
    public Transform manualMovementTransform;
    private Vector3 cameraFollowPosition;

    private float zoom = 8f;
    [SerializeField]
    public MyTaskSystem taskSystem;


    [SerializeField]
    WorkerTaskAI npc;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.Setup(() => playerTransform.position, () => zoom);

        //tasksystem setup
        this.taskSystem = GetComponent<MyTaskSystem>();
        npc.Setup();


        FunctionTimer.Create(() =>
        {
            Debug.Log("Task added");
            MyTaskSystem.Task task = new MyTaskSystem.Task.MoveToPosition { targetPosition = new Vector3(0f,0f) };
            taskSystem.AddTask(task);
        }, 5f);


    }

    // Update is called once per frame
    void Update()
    {
        HandleZoom();
        if (!locked) {
            HandleManualMovement();
            HandleEdgeScrolling();
        }
    }
    
    public void LockUnlockCameraOnPlayer ()
    {
        if (locked)
        {
            cameraFollowPosition = playerTransform.position;
            cameraFollow.SetGetCameraFollowPositionFunc(() => cameraFollowPosition);
            locked = false;
        }
        else
        {
            cameraFollow.SetGetCameraFollowPositionFunc(() => playerTransform.position); 
            locked = true;
        }

    }
    private void HandleZoom() {
        float zoomChangeAmount = 50f;
        if (Input.mouseScrollDelta.y > 0) { 
            zoom -= zoomChangeAmount * Time.deltaTime * 10f;
        }       
        if (Input.mouseScrollDelta.y < 0) { 
            zoom += zoomChangeAmount * Time.deltaTime * 10f;
        }
        

        zoom = Mathf.Clamp(zoom, 8f,40f);

    }

    private void HandleManualMovement()
    {
        float moveAmount = 1f;
        if (Input.GetKey(KeyCode.W))
        {
            cameraFollowPosition.y += moveAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            cameraFollowPosition.y -= moveAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            cameraFollowPosition.x += moveAmount * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            cameraFollowPosition.x -= moveAmount * Time.deltaTime;
        }
    }
    private void HandleEdgeScrolling()
    {
        float edgeSize = 30f;
        float moveAmount = 10f;
        if (Input.mousePosition.x > Screen.width - edgeSize) {
            //edge right
            cameraFollowPosition.x += moveAmount * Time.deltaTime;
            
        }
        if (Input.mousePosition.x < edgeSize)
        {
            //edge left
            cameraFollowPosition.x -= moveAmount * Time.deltaTime;
        }
        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            //edge up
            cameraFollowPosition.y += moveAmount * Time.deltaTime;
        }
        if (Input.mousePosition.y <edgeSize)
        {
            //edge down
            cameraFollowPosition.y -= moveAmount * Time.deltaTime;
        }
    }

}
