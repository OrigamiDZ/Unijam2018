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
    private int maxpopulation;

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
    private int fertilityRate;

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
    public int GetNumberOfHousesLVL1()
    {
        return numberOfHousesLVL1;
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
    public void SetNumberOfFieldsLVL1(int setNumberOfFields)
    {
        numberOfFieldsLVL1 = setNumberOfFields;
    }
    public void SetNumberOfHousesLVL1(int setNumberOfHouses)
    {
        numberOfHousesLVL1 = setNumberOfHouses;
    }
    public void SetNumberOfSacrified(int setNumberOfSacrified)
    {
        numberOfSacrified = setNumberOfSacrified;
    }

    public void Set_food_consumed_by_hab(int setfood_consumed_by_hab)
    {
        food_consumed_by_hab = setfood_consumed_by_hab;
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
            yield return new WaitForSeconds(1);

            // recalcul of the max population
            maxpopulation = numberOfHousesLVL1 * capacityHouseLVL1 + numberOfHousesLVL2 * capacityHouseLVL2;

            // update of the population
            if (people + people*fertilityRate <= maxpopulation)
            {
                people = people + people * fertilityRate;
            }
            else
            {
                people = maxpopulation;
            }

            // update of the food
            food = food + numberOfFieldsLVL1 * productivityOfFieldsLVL1 + numberOfFieldsLVL2 * productivityOfFieldsLVL2 - people * food_consumed_by_hab; 


        }
    }


    // Use this for initialization
    void Start () {
        lunarCycleNumber = 0;
        StartCoroutine("UpdateOfRessources");
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
	}
}
