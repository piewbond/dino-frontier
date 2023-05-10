using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] private List<ResourceTypeSO> resources = new List<ResourceTypeSO>();
    [SerializeField] private List<GameObject> barPanel = new List<GameObject>();

    private void SetBar(ResourceTypeSO resource) {
        
        float barLength = resource.currentAmount / resource.maxCapacity;
        GameObject.Find(resource.barName).GetComponent<SliderChanger>().SetSlider(barLength);

    }

    public void AddResource(ResourceTypeSO resourceType, float amount)
    {
        foreach (ResourceTypeSO res in resources)
        {
            if (resourceType == res) { 
                res.currentAmount += amount;
                SetBar(res);
            }
        }
    }

    public void RemoveResource(ResourceTypeSO resourceType) { 
    
    
    }

    public void AddResourceType(ResourceTypeSO resourceType) {
        resources.Add(resourceType);
    }
    public void AddStatusBar(GameObject bar) {
        barPanel.Add(bar);
    }
}
