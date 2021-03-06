﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager_Aure: MonoBehaviour {

    [SerializeField]
    private GameObject cityGameObject;
    [SerializeField]
    private GameObject canvaDisaster;
    [SerializeField]
    private TextMeshProUGUI pauseText;

    [SerializeField]
    private float percentChanceOfADisaster;
    [SerializeField]
    private float percentChanceOfARaid;
    [SerializeField]
    private int totalOfLunarCircle;
    [SerializeField]
    private float jesusFinalInahibitantsRessource;
    [SerializeField]
    private float jesusFinalSoulsRessource;
    

    private bool gameIsPaused;

    private int currentLunarCycleNumber;

    private CityShems cityScript;

    private List<GameObject> my_disasters = new List<GameObject>();
    private int numberOfDisasters;

    public bool GetGameIsPaused()
    {
        return gameIsPaused;
    }


    public void PutGameInPause(bool inPause)
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

    void CreateOrNotAnEvent()
    {
        // set (or not) a random event
        if (Random.Range(0, 9999) <= 9999 * percentChanceOfADisaster)
        {
            setActifARandomDisaster();  // set (or not) randomly a disaster
        }
        else
        {
            if (Random.Range(0, 9999) <= 9999 * percentChanceOfARaid)
            {
                setActifARandomRaid();  // set (or not) randomly a raid
            }
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

    void setActifARandomRaid()
    {
        PlayerPrefs.SetInt("food", cityScript.Get_food());
        PlayerPrefs.SetInt("people", cityScript.Get_people());
        PlayerPrefs.SetInt("souls", cityScript.Get_souls());
        PlayerPrefs.SetInt("numberOfFieldsLVL1", cityScript.GetNumberOfFieldsLVL1());
        PlayerPrefs.SetInt("numberOfFieldsLVL2", cityScript.GetNumberOfFieldsLVL2());
        PlayerPrefs.SetInt("numberOfHousesLVL1", cityScript.GetNumberOfHousesLVL1());
        PlayerPrefs.SetInt("numberOfHousesLVL2", cityScript.GetNumberOfHousesLVL2());
        PlayerPrefs.SetInt("lunarCycleNumber", cityScript.GetLunarCycleNumber());
        PlayerPrefs.SetInt("timer", cityScript.getTimer());

        PlayerPrefs.SetFloat("ourRessourceSent", cityScript.Get_people());

        float randomEnnemyForce = Random.Range(60, 140)/100.0f;

        PlayerPrefs.SetFloat("enemyRessource", cityScript.Get_people()* randomEnnemyForce);

        SceneManager.LoadScene(4);

    }

    private void Update()
    {
        if (currentLunarCycleNumber < cityScript.GetLunarCycleNumber())
        {
            currentLunarCycleNumber = cityScript.GetLunarCycleNumber();
            CreateOrNotAnEvent();
        }

        if (currentLunarCycleNumber >= totalOfLunarCircle)
        {
            PlayerPrefs.SetFloat("ourRessourceSentFinal", cityScript.Get_people());
            PlayerPrefs.SetFloat("jesusInahibitantsRessourceFinal", jesusFinalInahibitantsRessource);
            PlayerPrefs.SetFloat("ourSoulsRessourceSentFinal", cityScript.Get_souls());
            PlayerPrefs.SetFloat("jesusSoulsRessourceFinal", jesusFinalSoulsRessource);

            SceneManager.LoadScene(5);
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

    public int getTotalLunarCycle()
    {
        return totalOfLunarCircle;
    }
}
