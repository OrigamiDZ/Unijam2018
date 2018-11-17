using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingsManagerMainGame_Lea : MonoBehaviour {
    GameObject UIBuildings;
    Text BuildingNameText;
    Sprite BuildingSprite;

    public void OnBuildingInteraction(GameObject Building)
    {
        UIBuildings.SetActive(true);
        BuildingNameText.text = Building.GetComponent<Building_Aure>().GetType().ToString();

    }
}
