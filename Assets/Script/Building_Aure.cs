using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Aure : MonoBehaviour {

    [SerializeField]
    private int deltaInhabitants;
    public int deltaInhabitantsUp;

    [SerializeField]
    private int deltaFood;
    public int deltaFoodUp;

    [SerializeField]
    private int deltaSouls;
    public int deltaSoulsUp;

    [SerializeField]
    private EnumBuildingType_Lea.BuildingType type;

    [SerializeField]
    private Sprite sprite;

    public int buildingCost;
    public int costUpgrade1;
    public Sprite selectedSprite;
    public int lvl;
    public Sprite upgradedSprite;
    public Sprite upgradedSelectSprite;
    private bool isUpgradedSprite = false;

    void Update()
    {
        if (lvl==2 && !isUpgradedSprite)
        {
            Debug.Log("Building upgraded");
            isUpgradedSprite = true;
            GetComponent<SpriteRenderer>().sprite = upgradedSprite;
        }
    }
    public int getDeltaInhabitants()
    {
        return deltaInhabitants;
    }

    public int getDeltaFood()
    {
        return deltaFood;
    }

    public int getDeltaSouls()
    {
        return deltaSouls;
    }

    public void setDeltaHabitants(int inhabitants)
    {
        deltaInhabitants = inhabitants;
    }

    public void setDeltaSouls(int souls)
    {
        deltaSouls = souls;
    }

    public void setDeltaFood(int food)
    {
        deltaFood = food;
    }

    public EnumBuildingType_Lea.BuildingType getBuildingType()
    {
        return type;
    }

    public void setSprite(Sprite newSprite){
        sprite = newSprite;
    }

    public Sprite getSprite()
    {
        if (lvl == 2)
        {
            return upgradedSprite;
        }
        else
        {
            return sprite;
        }
    }

}
