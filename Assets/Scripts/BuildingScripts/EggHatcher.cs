using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggHatcher : MonoBehaviour
{

    [SerializeField] private Transform NPCPrefab;
    private int maxNPC = 5;
    private int NPCcount = 0;
    private float spawnTime = 5f;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HatchEgg() {
        if (NPCcount < maxNPC) {
            FunctionTimer.Create(SpawnNPC, spawnTime);
            NPCcount++;
        }
    }

    public void SpawnNPC() {
        Instantiate(NPCPrefab, new Vector2(transform.position.x, transform.position.y-0.5f), Quaternion.identity);
        NPCcount++;
    }


}
