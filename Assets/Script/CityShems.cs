using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityShems : MonoBehaviour {

    [SerializeField]
    private int food;
    [SerializeField]
    private int people;
    [SerializeField]
    private int souls;

    [SerializeField]
    private int numberOfFieldsLVL1;
    [SerializeField]
    private int productivityOfFieldsLVL1;
    [SerializeField]
    private int numberOfFieldsLVL2;
    [SerializeField]
    private int productivityOfFieldsLVL2;

    [SerializeField]
    private int numberOfHousesLVL1;
    [SerializeField]
    private int capacityHouseLVL1;
    [SerializeField]
    private int numberOfHousesLVL2;
    [SerializeField]
    private int capacityHouseLVL2;

    [SerializeField]
    private int numberOfSacrified;

    [SerializeField]
    private int food_consumed_by_hab;
    [SerializeField]
    private float fertilityRate;
    [SerializeField]
    private float deathRateWhenNoFood;

    [SerializeField]
    private float timeOfAnRessourceUpdate;
    [SerializeField]
    private float timeOfALunarCircle;

    private float bonusFertility;
    private float bonusFood;
    private float bonusSoulsProduction;


    private int maxpopulation;
    private int lunarCycleNumber;
    public GameObject sliderMoon;
    public GameObject sliderJesus;
    public GameObject gameManager;
    private int timer;

    private bool gameIsPausedManager;

    //Getter
    public int Get_food() {
        return food;
    }
    public int Get_people()
    {
        return people;
    }
    public int Get_souls()
    {
        return souls;
    }
    public int Get_maxpopulation()
    {
        return maxpopulation;
    }

    public int GetNumberOfFieldsLVL1()
    {
        return numberOfFieldsLVL1;
    }
    public int GetNumberOfFieldsLVL2()
    {
        return numberOfFieldsLVL2;
    }

    public int GetNumberOfHousesLVL1()
    {
        return numberOfHousesLVL1;
    }
    public int GetNumberOfHousesLVL2()
    {
        return numberOfHousesLVL2;
    }
    public int GetNumberOfSacrified()
    {
        return numberOfSacrified;
    }

    public int Get_food_consumed_by_hab()
    {
        return food_consumed_by_hab;
    }

    //Setter
    public void Set_food(int setfood)
    {
        food = setfood;
    }
    public void Set_people(int setpeople)
    {
        people = setpeople;
    }
    public void Set_souls(int setsouls)
    {
        souls = setsouls;
    }
    public void Set_maxpopulation(int setmaxpop)
    {
        maxpopulation = setmaxpop;
    }
    public void SetNumberOfFieldsLVL1(int setNumberOfFieldsLVL1)
    {
        numberOfFieldsLVL1 = setNumberOfFieldsLVL1;
    }
    public void SetNumberOfFieldsLVL2(int setNumberOfFieldsLVL2)
    {
        numberOfFieldsLVL2 = setNumberOfFieldsLVL2;
    }
    public void SetNumberOfHousesLVL1(int setNumberOfHousesLVL1)
    {
        numberOfHousesLVL1 = setNumberOfHousesLVL1;
    }
    public void SetNumberOfHousesLVL2(int setNumberOfHousesLVL2)
    {
        numberOfHousesLVL2 = setNumberOfHousesLVL2;
    }

    public void SetNumberOfSacrified(int setNumberOfSacrified)
    {
        numberOfSacrified = setNumberOfSacrified;
    }

    public void Set_food_consumed_by_hab(int setfood_consumed_by_hab)
    {
        food_consumed_by_hab = setfood_consumed_by_hab;
    }

    public int GetLunarCycleNumber()
    {
        return lunarCycleNumber;
    }

    public void SetLunarCycleNumber(int setLunarCycleNumber)
    {
        lunarCycleNumber = setLunarCycleNumber;
    }

    public float GetTimeOfAnRessourceUpdate()
    {
        return timeOfAnRessourceUpdate;
    }

    public void SetTimeOfAnRessourceUpdate(int setTimeOfAnRessourceUpdate)
    {
        timeOfAnRessourceUpdate = setTimeOfAnRessourceUpdate;
    }

    public float GetTimeOfALunarCircle()
    {
        return timeOfALunarCircle;
    }

    public void SetTimeOfALunarCircle(int setTimeOfALunarCircle)
    {
        timeOfALunarCircle = setTimeOfALunarCircle;
    }

    public void SetBonusFertility(float setBonusFertility)
    {
        bonusFertility = setBonusFertility;
    }

    public void SetBonusFood(float setBonusFood)
    {
        bonusFood = setBonusFood;
    }

    public void SetBonusSoulsProduction(float setBonusSoulsProduction)
    {
        bonusSoulsProduction = setBonusSoulsProduction;
    }

    public int getTimer()
    {
        return timer;
    }

    public void setGameIsPausedManager(bool setGameIsPausedManages)
    {
        gameIsPausedManager = setGameIsPausedManages;
    }

    public void ReStartGame()
    {
        StartCoroutine("UpdateOfRessources");
        StartCoroutine("timerMoonAndJesus");
    }

    public void StopGame()
    {
        StopCoroutine("UpdateOfRessources");
        StopCoroutine("timerMoonAndJesus");
        StopAllCoroutines();
    }


    IEnumerator UpdateOfRessources()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeOfAnRessourceUpdate);
            // recalcul of the max population
            maxpopulation = numberOfHousesLVL1 * capacityHouseLVL1 + numberOfHousesLVL2 * capacityHouseLVL2;


            // update of the food
            int foodProducted = numberOfFieldsLVL1 * (int)(productivityOfFieldsLVL1 + bonusFood) + numberOfFieldsLVL2 * (int)(productivityOfFieldsLVL2 + bonusFood);
            int foodConsumed = people * food_consumed_by_hab;

            if (food + foodProducted < foodConsumed)
            {
                people = people - (int)(people * deathRateWhenNoFood);
                food = 0;

            }
            else
            {
                food = food + foodProducted - foodConsumed;
            }

            // update of the population
            if (food != 0)
            {
                int babies = (int)(people * (fertilityRate + bonusFertility)) + 1;
                if (people + babies <= maxpopulation)
                {
                    people = people + babies;
                }
                else
                {
                    people = maxpopulation;
                }
            }
            
        }
    }



    // Use this for initialization
    void Start () {
        
        maxpopulation = numberOfHousesLVL1 * capacityHouseLVL1 + numberOfHousesLVL2 * capacityHouseLVL2;
        sliderMoon.GetComponent<Slider>().maxValue = timeOfALunarCircle;
        sliderMoon.GetComponent<Slider>().value = 0;
        sliderJesus.GetComponent<Slider>().maxValue = gameManager.GetComponent<GameManager_Aure>().getTotalLunarCycle();
        sliderJesus.GetComponent<Slider>().value = 0;

        if (PlayerPrefs.GetString("IsItDebut").Equals("Yes"))
        {
            lunarCycleNumber = 0;
            timer = 0;
            bonusFertility = 0;
            bonusFood = 0;
            bonusSoulsProduction = 0;
        }
        else
        {
            bonusFertility = 0;
            bonusFood = 0;
            bonusSoulsProduction = 0;
            food = PlayerPrefs.GetInt("food");
            people = PlayerPrefs.GetInt("people");
            souls = PlayerPrefs.GetInt("souls");
            numberOfFieldsLVL1 = PlayerPrefs.GetInt("numberOfFieldsLVL1");
            numberOfFieldsLVL2 = PlayerPrefs.GetInt("numberOfFieldsLVL2");
            numberOfHousesLVL1 = PlayerPrefs.GetInt("numberOfHousesLVL1");
            numberOfHousesLVL2 = PlayerPrefs.GetInt("numberOfHousesLVL2");
            lunarCycleNumber = PlayerPrefs.GetInt("lunarCycleNumber");
            timer = PlayerPrefs.GetInt("timer");
            bonusFertility = PlayerPrefs.GetFloat("bonusFertility");
            bonusFood = PlayerPrefs.GetFloat("bonusFood");
            bonusSoulsProduction = PlayerPrefs.GetFloat("bonusSoulsProduction");
        }

        ReStartGame();
        PlayerPrefs.SetString("IsItDebut", "No");
    }
	
	// Update is called once per frame


    IEnumerator timerMoonAndJesus()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            if (timer < timeOfALunarCircle)
            {                
                timer++;
                sliderMoon.GetComponent<Slider>().value++;
            }
            else
            {
                timer = 0;
                sliderMoon.GetComponent<Slider>().value = 0;
                sliderJesus.GetComponent<Slider>().value++;

                souls += (int)(numberOfSacrified + numberOfSacrified * bonusSoulsProduction);
                people -= numberOfSacrified;
                lunarCycleNumber++;


                if (people <= 0)
                {
                    souls = souls + people; // rééquillibrage souls
                    people = 0;
                    Debug.Log("GameOver");
                    StopGame();
                }
            }
        }
    }


}
