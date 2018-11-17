using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagerMainGame_Lea : MonoBehaviour {
    [SerializeField]
    Canvas BuildingsCanvas;
    [SerializeField]
    private Text PopulationNumberUI;
    [SerializeField]
    private Text FoodNumberUI;
    [SerializeField]
    private Text SoulsNumberUI;
    /*
    [SerializedField]
    private Text MoralUI;
    */
    [SerializeField]
    private GameObject City;
	

	// Update is called once per frame
	void Update () {
        //Set the different text for the different resources

        PopulationNumberUI.text = City.GetComponent<CityShems>().Get_people().ToString() + "/" + City.GetComponent<CityShems>().Get_maxpopulation().ToString();
        FoodNumberUI.text = City.GetComponent<CityShems>().Get_food().ToString();
        SoulsNumberUI.text = City.GetComponent<CityShems>().Get_souls().ToString();
        //MoralNumberUI.text = City.GetComponent<City>().globalMoral;
    }

}
