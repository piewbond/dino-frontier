using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> buildingTypeSOs;
    [SerializeField] private BuildHandler buildingManager;

    private void Awake()
    {
        Transform buildingBtnTemplate = transform.Find("buildingBtnTemplate");
        buildingBtnTemplate.gameObject.SetActive(false);
        int index = 0;
        foreach (BuildingTypeSO buildingTypeSO in buildingTypeSOs)
        {
            Transform buildingBtnTransform = Instantiate(buildingBtnTemplate, transform);
            buildingBtnTransform.gameObject.SetActive(true);

            buildingBtnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -index * 30);
            buildingBtnTransform.Find("image").GetComponent<Image>().sprite = buildingTypeSO.sprite;

            buildingBtnTransform.GetComponent<Button>().onClick.AddListener(() => { 
                buildingManager.SetActiveBuildingType(buildingTypeSO);
            });
            index++;
        }
    }
}
