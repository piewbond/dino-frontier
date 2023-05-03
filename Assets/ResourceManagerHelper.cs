using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManagerHelper : MonoBehaviour
{

    [SerializeField] private List<ResourceTypeSO> resources;
    [SerializeField] private List<GameObject> barPanel;

    // Start is called before the first frame update
    void Start()
    {
        foreach (ResourceTypeSO resourceType in resources)
        {
            ResourceManager.AddResourceType(resourceType);
        }
        foreach (GameObject bar in barPanel)
        {
            ResourceManager.AddStatusBar(bar);
        }
    }
    void Update()
    {
        
    }

}
