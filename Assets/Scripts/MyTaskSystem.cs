using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyTaskSystem : MonoBehaviour
{

    public abstract class Task {

        public class MoveToPosition : Task{
            
            public Vector3 targetPosition;
        }
        public class Repair : Task {
            
        }
    }
    private List<Task> tasks;
    public MyTaskSystem() { 
        //tasks = new List<Task>();
        
    }
    

    public Task RequestNextTask() { 
        if (tasks.Count > 0) {
            Task task = tasks[0];
            tasks.RemoveAt(0);
            return task;
        } else
        {
            return null;
        }
    
    }

    public void AddTask(Task task)
    {
        tasks.Add(task);
    }

    // Start is called before the first frame update
    void Start()
    {
        tasks = new List<Task>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
