using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulidingParent : MonoBehaviour
{
    private float capacity;
    private float resourceAmount;
    //[SerializeField] private ResourceManager resourceManager;
    [SerializeField] private ResourceTypeSO resourceType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddResources();
    }
    public void SetResourceAmount(float amount) { 
        resourceAmount = amount;
    }
    private void AddResources() { 
        
    }
}
