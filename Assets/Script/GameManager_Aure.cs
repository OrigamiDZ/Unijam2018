using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager_Aure: MonoBehaviour {

    [SerializeField]
    private GameObject cityGameObject;
    [SerializeField]
    private GameObject canvaDisaster;
    [SerializeField]
    private TextMeshProUGUI pauseText;

    [SerializeField]
    private float percentChanceOfADisaster;

    private bool gameIsPaused;

    private int currentLunarCycleNumber;

    private CityShems cityScript;

    private List<GameObject> my_disasters = new List<GameObject>();
    private int numberOfDisasters;

    private void PutGameInPause(bool inPause)
    {
        if (inPause)
        {
            gameIsPaused = true;
            cityScript.StopGame();
            pauseText.text = "Pause";
        }
        else
        {
            gameIsPaused = false;
            cityScript.ReStartGame();
            pauseText.text = "";
        }
    }

    private void Start()
    {
        numberOfDisasters = 0;
        cityScript = cityGameObject.GetComponent<CityShems>();
        for (int i = 0; i < canvaDisaster.transform.childCount; i++)
        {
            my_disasters.Add(canvaDisaster.transform.GetChild(i).gameObject);
            numberOfDisasters ++;
        }
        if (numberOfDisasters == 0)
        {
            Debug.Log("Not enought disasters");
        }
        currentLunarCycleNumber = cityScript.GetLunarCycleNumber();
        pauseText.text = "";
    }

    void CreateOrNotADisaster()
    {
        // set (or not) a random event
        if (Random.Range(0, 9999) <= 9999 * percentChanceOfADisaster)
        {
            Debug.Log("A disaster happened");
            setActifARandomDisaster();  // set (or not) randomly a disaster
        }
    }

    void setActifARandomDisaster()
    {
        int enumLenght = System.Enum.GetValues(typeof(EnumDisasterTypes_Aure.DisasterType)).Length;
        int randomDisaster = Random.Range(0, enumLenght);
        cityScript.Set_food(cityScript.Get_food() - (int)(my_disasters[randomDisaster].GetComponent<Disaster_Aure>().GetPercentLostFood() * cityScript.Get_food()));
        cityScript.Set_people(cityScript.Get_people() - (int)(my_disasters[randomDisaster].GetComponent<Disaster_Aure>().GetPercentLostInhabitants() * cityScript.Get_people()));
        cityScript.Set_souls(cityScript.Get_souls() - (int)(my_disasters[randomDisaster].GetComponent<Disaster_Aure>().GetPercentLostSouls() * cityScript.Get_souls()));
        my_disasters[randomDisaster].SetActive(true);
        my_disasters[randomDisaster].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = 
            "- " + (int)(my_disasters[randomDisaster].GetComponent<Disaster_Aure>().GetPercentLostFood() * cityScript.Get_food()) + 
            " nourritures \n" +
            "- " + (int)(my_disasters[randomDisaster].GetComponent<Disaster_Aure>().GetPercentLostSouls() * cityScript.Get_souls()) + 
            " habitants";
        PutGameInPause(true);
    }

    private void Update()
    {
        if (currentLunarCycleNumber < cityScript.GetLunarCycleNumber())
        {
            currentLunarCycleNumber = cityScript.GetLunarCycleNumber();
            CreateOrNotADisaster();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameIsPaused)
            {
                PutGameInPause(false);
            }
            else
            {
                PutGameInPause(true);
            }
        }
    }
}
