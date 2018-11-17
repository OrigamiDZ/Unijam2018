using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private int maxpopulation;
    private int lunarCycleNumber;
    private float time;


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
    public float Get_time()
    {
        return time;
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

    public void Lunar_Cycle_Update()
    {      
        souls += numberOfSacrified;
        people -= numberOfSacrified;
    }

    IEnumerator UpdateOfRessources()
    {
        while (true)
        {           
            // recalcul of the max population
            maxpopulation = numberOfHousesLVL1 * capacityHouseLVL1 + numberOfHousesLVL2 * capacityHouseLVL2;


            // update of the food
            int foodProducted = numberOfFieldsLVL1 * productivityOfFieldsLVL1 + numberOfFieldsLVL2 * productivityOfFieldsLVL2;
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
                int babies = (int)(people * fertilityRate) + 1;
                if (people + babies <= maxpopulation)
                {
                    people = people + babies;
                }
                else
                {
                    people = maxpopulation;
                }
            }
            yield return new WaitForSeconds(1);
        }
    }


    // Use this for initialization
    void Start () {
        lunarCycleNumber = 0;
        maxpopulation = numberOfHousesLVL1 * capacityHouseLVL1 + numberOfHousesLVL2 * capacityHouseLVL2;

        StartCoroutine("UpdateOfRessources");
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}
}
