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
    GameObject[] buildingsPrefabs;

    public GameObject selectedTile;

    private void Start()
    {
        UIBuildings.SetActive(false);
        UIFreeArea.SetActive(false);
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
        Vector3 offset = new Vector3(10f,18f,0f);
        Vector2 position = selectedTile.transform.position + offset;
        string layerName = selectedTile.GetComponent<SpriteRenderer>().sortingLayerName;
        GameObject newBuilding = Instantiate(buildingsPrefabs[0], position, Quaternion.identity, city.transform);
        newBuilding.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
        GameObject oldObject = selectedTile;
        selectedTile = newBuilding;
        Destroy(oldObject);
        UIFreeArea.SetActive(false);
    }

    public void BuildFarm()
    {
        Vector3 offset = new Vector3(8f, 22f,0f);
        Vector2 position = selectedTile.transform.position + offset;
        string layerName = selectedTile.GetComponent<SpriteRenderer>().sortingLayerName;
        GameObject newBuilding = Instantiate(buildingsPrefabs[1], position, Quaternion.identity, city.transform);
        newBuilding.GetComponent<SpriteRenderer>().sortingLayerName = layerName;
        GameObject oldObject = selectedTile;
        selectedTile = newBuilding;
        Destroy(oldObject);
        UIFreeArea.SetActive(false);
    }
}
