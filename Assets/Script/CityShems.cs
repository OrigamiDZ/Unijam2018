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
    public int timer;


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

    public void ReStartGame()
    {
        StartCoroutine("UpdateOfRessources");
        StartCoroutine("LunarCircle");
    }

    public void StopGame()
    {
        StopCoroutine("UpdateOfRessources");
        StopCoroutine("LunarCircle");
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

    IEnumerator LunarCircle()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(timeOfALunarCircle);

            souls += (int)(numberOfSacrified * bonusSoulsProduction);
            people -= numberOfSacrified;
            lunarCycleNumber++;
            StartCoroutine("timerMoonAndJesus");

            if (people <= 0)
            {
                souls = souls + people; // rééquillibrage souls
                people = 0;
                Debug.Log("GameOver");
                StopGame();
            }

        }
    }

    // Use this for initialization
    void Start () {
        lunarCycleNumber = 0;
        maxpopulation = numberOfHousesLVL1 * capacityHouseLVL1 + numberOfHousesLVL2 * capacityHouseLVL2;
        sliderMoon.GetComponent<Slider>().maxValue = timeOfALunarCircle;
        sliderMoon.GetComponent<Slider>().value = 0;
        timer = 0;
        StartCoroutine("timerMoonAndJesus");

        ReStartGame();
    }
	
	// Update is called once per frame


    IEnumerator timerMoonAndJesus()
    {
        while (true)
        {
            if(timer < timeOfALunarCircle)
            {
                yield return new WaitForSecondsRealtime(1);
                timer++;
                sliderMoon.GetComponent<Slider>().value++;
            }
            if(timer == timeOfALunarCircle)
            {
                timer = 0;
                sliderMoon.GetComponent<Slider>().value = 0;
                break;
            }
        }

    }


}
