using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    [SerializeField] private ResourceTypeSO resourceType;
    //[SerializeField] private ResourceManager resourceManager;
    [SerializeField] private float resourceSpeed; // how much resource does it add when updateing

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float amount = Time.deltaTime * resourceSpeed;
        ResourceManager.AddResource(resourceType, amount);
    }

}
