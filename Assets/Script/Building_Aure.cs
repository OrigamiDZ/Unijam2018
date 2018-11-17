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

    void setDeltaHabitants(int habitants)
    {
        deltaHabitants = habitants;
    }

    void setDeltaSouls(int souls)
    {
        deltaSouls = souls;
    }

}
