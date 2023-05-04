using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{

    [SerializeField] private ResourceTypeSO resourceType;
    private ResourceManager resourceManager;
    [SerializeField] private float resourceSpeed; // how much resource does it add when updateing

    // Start is called before the first frame update
    void Start()
    {
        resourceManager = GameObject.Find("ResourceManager").GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float amount = Time.deltaTime * resourceSpeed;
        resourceManager.AddResource(resourceType, amount);
    }
    //TODO production

}
