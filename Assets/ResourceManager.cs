using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public static class ResourceManager
{

    private static List<ResourceTypeSO> resources = new List<ResourceTypeSO>();
    private static List<GameObject> barPanel = new List<GameObject>();

    private static void SetBars() {
        int i = 0;
        foreach (ResourceTypeSO resource in resources)
        {
            float barLength = resource.currentAmount / resource.maxCapacity;
            barPanel[i].GetComponent<SliderChanger>().SetSlider(barLength);
            i++;
        }
    }

    public static void AddResource(ResourceTypeSO resourceType, float amount)
    {
        foreach (ResourceTypeSO res in resources)
        {
            if (resourceType == res) { 
                res.currentAmount += amount;
            }
        }
        SetBars();
    }

    public static void RemoveResource(ResourceTypeSO resourceType) { 
    
    
    }

    public static void AddResourceType(ResourceTypeSO resourceType) {
        resources.Add(resourceType);
    }
    public static void AddStatusBar(GameObject bar) {
        barPanel.Add(bar);
    }
}
