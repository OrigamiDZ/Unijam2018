using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Aure: MonoBehaviour {

    [SerializeField]
    private GameObject cityGameObject;

    [SerializeField]
    private float timeOfALunarCircle;

    private CityShems cityScript;

    private float timeForNextLunarCircle;

    private void Start()
    {
        cityScript = cityGameObject.GetComponent<CityShems>();
        timeForNextLunarCircle = cityScript.Get_time() + timeOfALunarCircle;

    }

    void LunarCircle()
    {
        if ( cityScript.Get_time() > timeForNextLunarCircle)
        {
            cityScript.Lunar_Cycle_Update(); // the function update the ressources values

            timeForNextLunarCircle = cityScript.Get_time() + timeOfALunarCircle;
        }


    }

    void Disaster()
    {

    }

}
