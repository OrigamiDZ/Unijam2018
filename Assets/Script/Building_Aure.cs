using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Aure : MonoBehaviour {

    [SerializeField]
    private int deltaHabitants;

    [SerializeField]
    private int deltaFood;

    [SerializeField]
    private int deltaSouls;

    [SerializeField]
    private EnumBuildingType_Lea.BuildingType type;

    [SerializeField]
    private Sprite sprite;

    public int getDeltaHabitants()
    {
        return deltaHabitants;
    }

    public int getDeltaFood()
    {
        return deltaFood;
    }

    public int getDeltaSouls()
    {
        return deltaSouls;
    }

    public void setDeltaHabitants(int habitants)
    {
        deltaHabitants = habitants;
    }

    public void setDeltaSouls(int souls)
    {
        deltaSouls = souls;
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
