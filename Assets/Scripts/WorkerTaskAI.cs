using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerTaskAI : MonoBehaviour
{
    private enum State
    {
        WaitingForNextTask,
        ExecutingTask,
    }

    private State state;
    private float waitingTimer;

    private bool isOnTask;

    private MyTaskSystem taskSystem;
    NpcControllerScript controller;

    // Update is called once per frame
    void Update()
    {
        //task system logic
        if (isOnTask)
        switch (state)
        {
            case State.WaitingForNextTask:
                waitingTimer -= Time.deltaTime;
                if (waitingTimer <= 0)
                {
                    float waitingTimerMax = .5f;
                    waitingTimer = waitingTimerMax;
                    RequestNextTask();
                }
                break;
            case State.ExecutingTask:
                break;

        }
    }

    //Setting up the task system
    public void Setup()
    {
        controller = GetComponent<NpcControllerScript>();
        this.taskSystem = GameObject.Find("GameHandler").GetComponent<MyTaskSystem>();
        state = State.WaitingForNextTask;
    }
    private void RequestNextTask()
    {
        if (taskSystem != null)
        {
            MyTaskSystem.Task task = taskSystem.RequestNextTask();
            if (task == null)
            {
                state = State.WaitingForNextTask;
            }
            else
            {
                state = State.ExecutingTask;
                switch (task)
                {
                    case MyTaskSystem.Task.MoveToPosition:
                        ExecuteTaskMoveToPosition(task as MyTaskSystem.Task.MoveToPosition);
                        break;
                    case MyTaskSystem.Task.Repair:
                        ExecuteTaskRepair(task as MyTaskSystem.Task.Repair);
                        break;
                    default:
                        Debug.Log("default");
                        break;
                }
            }
        }
    }

    private void ExecuteTaskRepair(MyTaskSystem.Task.Repair repair)
    {
        Debug.Log("repair");
    }

    public void ExecuteTaskMoveToPosition(MyTaskSystem.Task.MoveToPosition moveToPositionTask)
    {
        controller.MoveTo(moveToPositionTask.targetPosition, () =>
        {
            state = State.WaitingForNextTask;
        });

    }

    public void EnableOnTask() { 
        this.isOnTask = true;
    }
    public void DisableOnTask()
    {
        this.isOnTask = false;
    }
}
