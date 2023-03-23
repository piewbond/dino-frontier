using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurScript : MonoBehaviour
{
    public Material material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BlurOn() => material.SetFloat("_Size", 1f);

    public void BlurOff() => material.SetFloat("_Size", 0f);

}
