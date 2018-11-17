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
        return sprite;
    }

}
