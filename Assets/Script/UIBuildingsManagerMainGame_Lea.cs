using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBuildingsManagerMainGame_Lea : MonoBehaviour {
    GameObject UIBuildings;

    public void OnBuildingInteraction(GameObject Building)
    {
        UIBuildings.SetActive(true);
        UIBuildings.transform.Find("BuildingName");
    }
}
