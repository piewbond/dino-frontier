using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ResourceTypeSO : ScriptableObject
{
    [SerializeField] public float maxCapacity;
    [SerializeField] public float minCapacity;
    [SerializeField] public string barName;
    [SerializeField] public float currentAmount;

}
