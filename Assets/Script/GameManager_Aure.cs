using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager_Aure: MonoBehaviour {

    [SerializeField]
    private GameObject cityGameObject;
    [SerializeField]
    private GameObject canva;
    [SerializeField]
    private float timeOfALunarCircle;
    [SerializeField]
    private int percentChanceOfADisaster;
    [SerializeField]
    private int percentChanceOfADisaster1;


    private CityShems cityScript;

    private float timeForNextLunarCircle;

    private Disaster_Aure[] my_disasters;

    private void Start()
    {
        cityScript = cityGameObject.GetComponent<CityShems>();
        timeForNextLunarCircle = cityScript.Get_time() + timeOfALunarCircle;

        my_disasters = canva.GetComponentsInChildren<Disaster_Aure>();

    }

    void LunarCircle()
    {
        // check if it's time for lunar change
        if ( cityScript.Get_time() > timeForNextLunarCircle)
        {
            cityScript.Lunar_Cycle_Update(); // the function update the ressources values

            CreateOrNotADisaster();

            timeForNextLunarCircle = cityScript.Get_time() + timeOfALunarCircle;
        }
    }

    void CreateOrNotADisaster()
    {
        // set (or not) a random event
        if (Random.Range(0, 9999) <= 9999 * (percentChanceOfADisaster / 100))
        {
            setActiftARandomDisaster();  // set (or not) randomly a disaster
        }
    }

    void setActiftARandomDisaster()
    {
        int randomDisaster = Random.Range(1, System.Enum.GetNames(typeof(EnumDisasterTypes_Aure)).Length);
        my_disasters[randomDisaster].gameObject.SetActive(true);
        cityScript.Set_food(cityScript.Get_food() - (my_disasters[randomDisaster].GetPercentLostFood() * cityScript.Get_food()));
        cityScript.Set_people(cityScript.Get_people() - (my_disasters[randomDisaster].GetPercentLostInhabitants() * cityScript.Get_people()));
        cityScript.Set_souls(cityScript.Get_souls() - (my_disasters[randomDisaster].GetPercentLostSouls() * cityScript.Get_souls()));
    }

    private void Update()
    {
        LunarCircle(); // check if it's time for lunar change

    }

}
