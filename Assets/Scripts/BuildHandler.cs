using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class BuildHandler : MonoBehaviour
{

    [SerializeField]  private BuildingTypeSO activeBuildingType;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            if(CanSpawnBuilding(activeBuildingType,mouseWorldPosition))
                Instantiate(activeBuildingType.prefab, mouseWorldPosition, Quaternion.identity);
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
}
