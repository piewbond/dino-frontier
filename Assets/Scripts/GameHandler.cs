
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private bool locked = true;

    public CameraFollow cameraFollow;
    public Transform playerTransform;
    public Transform manualMovementTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow.Setup(() => playerTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LockUnlockCameraOnPlayer ()
    {
        if (!locked) {
            cameraFollow.SetGetCameraFollowPositionFunc(() => playerTransform.position);
            locked = true;
        } else { 
            cameraFollow.SetGetCameraFollowPositionFunc(() => manualMovementTransform.position);
            locked = false;
        }

    }

}
