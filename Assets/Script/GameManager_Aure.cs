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

    private Disaster_Aure[] my_disasters;

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
        cityScript = cityGameObject.GetComponent<CityShems>();
        my_disasters = canvaDisaster.GetComponentsInChildren<Disaster_Aure>();
        currentLunarCycleNumber = cityScript.GetLunarCycleNumber();
        pauseText.text = "";
    }

    void CreateOrNotADisaster()
    {
        // set (or not) a random event
        if (Random.Range(0, 9999) <= 9999 * (percentChanceOfADisaster / 100))
        {
            setActifARandomDisaster();  // set (or not) randomly a disaster
        }
    }

    void setActifARandomDisaster()
    {
        int randomDisaster = Random.Range(1, System.Enum.GetNames(typeof(EnumDisasterTypes_Aure)).Length);
        cityScript.Set_food(cityScript.Get_food() - (int)(my_disasters[randomDisaster].GetPercentLostFood() * cityScript.Get_food()));
        cityScript.Set_people(cityScript.Get_people() - (int)(my_disasters[randomDisaster].GetPercentLostInhabitants() * cityScript.Get_people()));
        cityScript.Set_souls(cityScript.Get_souls() - (int)(my_disasters[randomDisaster].GetPercentLostSouls() * cityScript.Get_souls()));
        my_disasters[randomDisaster].gameObject.SetActive(true);
        my_disasters[randomDisaster].gameObject.GetComponentInChildren<TextMeshProUGUI>().text = 
            "- " + (int)(my_disasters[randomDisaster].GetPercentLostFood() * cityScript.Get_food()) + 
            " nourritures \n " + 
            (int)(my_disasters[randomDisaster].GetPercentLostSouls() * cityScript.Get_souls()) + 
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
