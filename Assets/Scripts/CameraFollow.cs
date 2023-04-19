using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera mycamera;
    private Func<Vector3> GetCameraFollowPositionFunc;
    private Func<float> GetCameraZoomFunc;


    private void Start() {
        mycamera = transform.GetComponent<Camera>();
    }

    public void Setup(Func<Vector3> GetCameraFollowPositionFunc, Func<float> GetCameraZoomFunc) {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }

    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc) {
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }

    public void SetCameraFollowPosition(Vector3 cameraFollowPosition) {
        SetGetCameraFollowPositionFunc(() => cameraFollowPosition);
    }
    public void SetCameraZoom(float cameraZoom) { 
        SetGetCameraZoomFunc(() => cameraZoom);
    }

    public void SetGetCameraZoomFunc(Func<float> GetCameraZoomFunc) {
        this.GetCameraZoomFunc = GetCameraZoomFunc;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        float cameraMoveSpeed = 2f;

        if (distance > 0)
        {

            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if (distanceAfterMoving > distance)
            {
                //if the camera overshoot the target
                newCameraPosition = cameraFollowPosition;
            }

            transform.position = newCameraPosition;
        }
    }

    private void HandleZoom() {
        float cameraZoom = GetCameraZoomFunc();

        float cameraZoomDifference = cameraZoom - mycamera.orthographicSize;
        float cameraZoomSpeed = 0.5f;

        mycamera.orthographicSize += cameraZoomDifference * cameraZoomSpeed * Time.deltaTime;

        if (cameraZoomDifference > 0)
        {
            if (mycamera.orthographicSize > cameraZoom)
            {
                mycamera.orthographicSize = cameraZoom;
            }
        }
        else {
            if (mycamera.orthographicSize < cameraZoom)
            {
                mycamera.orthographicSize = cameraZoom;
            }
        }
    }

}
