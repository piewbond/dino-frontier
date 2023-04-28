using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BuildHandler : MonoBehaviour
{

    [SerializeField]  private BuildingTypeSO activeBuildingType;
    [SerializeField] private Transform buildingBasePrefab;
    private GameObject building;
    private Transform clone;

    // Update is called once per frame
    void Update()
    {

        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        clone.transform.position = mouseWorldPosition;
            if (CanSpawnBuilding(activeBuildingType, mouseWorldPosition) )
            {
                //set blue
                SetBuildingColor(Color.blue);
            }
            else
            {
                //set red
                SetBuildingColor(Color.red);
            }
        

        if (Input.GetMouseButton(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
                Destroy(clone.gameObject);

            if (CanSpawnBuilding(activeBuildingType, mouseWorldPosition) ) {
                Instantiate(activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);
                Destroy(clone.gameObject);
                this.gameObject.SetActive(false);
            }
        }
        
    }

    public void SetActiveBuildingType(BuildingTypeSO buildingTypeSO) { 
        activeBuildingType = buildingTypeSO;
    }


    // Get Mouse Position in World with Z = of
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }

    private bool CanSpawnBuilding(BuildingTypeSO buildingTypeSO, Vector3 position) {
        BoxCollider2D buildingBoxCollider2D = buildingTypeSO.prefab.GetComponent<BoxCollider2D>();
        if (Physics2D.OverlapBox(position + (Vector3)buildingBoxCollider2D.offset, buildingBoxCollider2D.size, 0) != null)
        {
            return false;
        }
        else { 
            return true;
        }

    }
    public void CreateBuildingBase() {
        Vector3 mouseWorldPosition = GetMouseWorldPosition();
        clone = Instantiate(buildingBasePrefab, mouseWorldPosition, Quaternion.identity);
    }

    public void SetBuildingColor(Color color)
    {
        Renderer renderer = clone.GetComponentInChildren<Renderer>();
        renderer.material.color = color;
    }
}
