using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingsManagerMainGame_Lea : MonoBehaviour {
    [SerializeField]
    GameObject city;

    [SerializeField]
    GameObject UIBuildings;
    [SerializeField]
    Text BuildingNameText;
    [SerializeField]
    Image BuildingSprite;
    [SerializeField]
    Text BuildingEffects;

    [SerializeField]
    GameObject UIFreeArea;
    [SerializeField]
    GameObject housePrefabs;
    [SerializeField]
    GameObject farmPrefabs;

    public GameObject selectedTile;
    private GameObject previousTile;

    private void Start()
    {
        UIBuildings.SetActive(false);
        UIFreeArea.SetActive(false);
        previousTile = selectedTile;
    }


    public void OnBuildingInteraction(GameObject Building)
    {
        UIFreeArea.SetActive(false);
        UIBuildings.SetActive(true);
        BuildingNameText.text = Building.GetComponent<Building_Aure>().getBuildingType().ToString();
        BuildingSprite.sprite = Building.GetComponent<Building_Aure>().getSprite();
        BuildingEffects.text = getEffectsBuilding(Building);
    }

    private string getEffectsBuilding(GameObject Building)
    {
        string buildingEffects = "";
        if(Building.GetComponent<Building_Aure>().getDeltaFood() != 0)
        {
            buildingEffects += "Food ";
            if(Building.GetComponent<Building_Aure>().getDeltaFood() > 0)
            {
                buildingEffects += "+ " + Building.GetComponent<Building_Aure>().getDeltaFood().ToString() + " ";
            }
            else
            {
                buildingEffects += " " + Building.GetComponent<Building_Aure>().getDeltaFood().ToString() + " ";
            }
        }
        if (Building.GetComponent<Building_Aure>().getDeltaInhabitants() != 0)
        {
            buildingEffects += "\nInhabitants ";
            if (Building.GetComponent<Building_Aure>().getDeltaInhabitants() > 0)
            {
                buildingEffects += "+ " + Building.GetComponent<Building_Aure>().getDeltaInhabitants().ToString() + " ";
            }
            else
            {
                buildingEffects += " " + Building.GetComponent<Building_Aure>().getDeltaInhabitants().ToString() + " ";
            }
        }
        if (Building.GetComponent<Building_Aure>().getDeltaSouls() != 0)
        {
            buildingEffects += "\nSouls ";
            if (Building.GetComponent<Building_Aure>().getDeltaSouls() > 0)
            {
                buildingEffects += "+ " + Building.GetComponent<Building_Aure>().getDeltaSouls().ToString() + " ";
            }
            else
            {
                buildingEffects += " " + Building.GetComponent<Building_Aure>().getDeltaSouls().ToString() + " ";
            }
        }
        return buildingEffects;
    }


    public void OnFreeAreaInteraction()
    {
        UIBuildings.SetActive(false);
        UIFreeArea.SetActive(true);
    }


    public void BuildHouse()
    {
        Debug.Log(housePrefabs.GetComponent<Building_Aure>().buildingCost <= city.GetComponent<CityShems>().Get_souls());
        if (housePrefabs.GetComponent<Building_Aure>().buildingCost <= city.GetComponent<CityShems>().Get_souls())
        {
            Debug.Log("Building house");
            city.GetComponent<CityShems>().Set_souls(city.GetComponent<CityShems>().Get_souls() - housePrefabs.GetComponent<Building_Aure>().buildingCost);
            Vector3 offset = new Vector3(10f, 18f, 0f);
            Vector2 position = selectedTile.transform.position + offset;
            string layerName = selectedTile.GetComponent<SpriteRenderer>().sortingLayerName;
            GameObject newBuilding = Instantiate(housePrefabs, position, Quaternion.identity, city.transform);
            newBuilding.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            newBuilding.GetComponent<Building_Aure>().lvl = 1;
            city.GetComponent<CityShems>().SetNumberOfHousesLVL1(city.GetComponent<CityShems>().GetNumberOfHousesLVL1() + 1);
            GameObject oldObject = selectedTile;
            selectedTile = newBuilding;
            Destroy(oldObject);
            UIFreeArea.SetActive(false);
        }
    }


    public void 

    public void BuildFarm()
    {
        Debug.Log(housePrefabs.GetComponent<Building_Aure>().buildingCost <= city.GetComponent<CityShems>().Get_souls());
        if (farmPrefabs.GetComponent<Building_Aure>().buildingCost <= city.GetComponent<CityShems>().Get_souls())
        {
            Debug.Log("Building farm");
            city.GetComponent<CityShems>().Set_souls(city.GetComponent<CityShems>().Get_souls() - farmPrefabs.GetComponent<Building_Aure>().buildingCost);
            Vector3 offset = new Vector3(8f, 22f, 0f);
            Vector2 position = selectedTile.transform.position + offset;
            string layerName = selectedTile.GetComponent<SpriteRenderer>().sortingLayerName;
            GameObject newBuilding = Instantiate(farmPrefabs, position, Quaternion.identity, city.transform);
            newBuilding.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
            newBuilding.GetComponent<Building_Aure>().lvl = 1;
            city.GetComponent<CityShems>().SetNumberOfFieldsLVL1(city.GetComponent<CityShems>().GetNumberOfFieldsLVL1() + 1);
            GameObject oldObject = selectedTile;
            selectedTile = newBuilding;
            Destroy(oldObject);
            UIFreeArea.SetActive(false);
        }
    }


    private void Update()
    {
        if (selectedTile)
        {
            if(previousTile != selectedTile)
            {
                if (previousTile)
                {
                    if (previousTile.tag == "FreeArea" || previousTile.name == "Temple")
                    {
                        previousTile.GetComponent<SpriteRenderer>().sprite = null;
                    }
                    else
                    {
                        previousTile.GetComponent<SpriteRenderer>().sprite = previousTile.GetComponent<Building_Aure>().getSprite();
                    }
                    previousTile = selectedTile;
                }
                else
                {
                    previousTile = selectedTile;
                }
            }
            selectedTile.GetComponent<SpriteRenderer>().sprite = selectedTile.GetComponent<Building_Aure>().selectedSprite;
        }
    }
}
