using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingsManagerMainGame_Lea : MonoBehaviour {
    [SerializeField]
    GameObject UIBuildings;
    [SerializeField]
    Text BuildingNameText;
    [SerializeField]
    Image BuildingSprite;
    [SerializeField]
    Text BuildingEffects;

    public void OnBuildingInteraction(GameObject Building)
    {
        UIBuildings.SetActive(true);
        BuildingNameText.text = Building.GetComponent<Building_Aure>().GetType().ToString();
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
                buildingEffects += "- " + Building.GetComponent<Building_Aure>().getDeltaFood().ToString() + " ";
            }
        }
        if (Building.GetComponent<Building_Aure>().getDeltaInhabitants() != 0)
        {
            buildingEffects += "Inhabitants ";
            if (Building.GetComponent<Building_Aure>().getDeltaInhabitants() > 0)
            {
                buildingEffects += "+ " + Building.GetComponent<Building_Aure>().getDeltaInhabitants().ToString() + " ";
            }
            else
            {
                buildingEffects += "- " + Building.GetComponent<Building_Aure>().getDeltaInhabitants().ToString() + " ";
            }
        }
        if (Building.GetComponent<Building_Aure>().getDeltaSouls() != 0)
        {
            buildingEffects += "Souls ";
            if (Building.GetComponent<Building_Aure>().getDeltaSouls() > 0)
            {
                buildingEffects += "+ " + Building.GetComponent<Building_Aure>().getDeltaSouls().ToString() + " ";
            }
            else
            {
                buildingEffects += "- " + Building.GetComponent<Building_Aure>().getDeltaSouls().ToString() + " ";
            }
        }
        return buildingEffects;
    }
}
