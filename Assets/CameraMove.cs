using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //camera
    private Camera mycamera;
    //player
    public Transform target;



    // Start is called before the first frame update
    void Start()
    {
        mycamera = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //space set camera on player character
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
            transform.position = newPos;

        }

    }
}
