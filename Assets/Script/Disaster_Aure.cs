using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Disaster_Aure : MonoBehaviour {

    [SerializeField]
    private EnumDisasterTypes_Aure.DisasterType disasterType;

    [SerializeField]
    private string textExplanatory;

    [SerializeField]
    private float percentLostInhabitants;

    [SerializeField]
    private float percentLostFood;

    [SerializeField]
    private float percentLostSouls;

    private TextMeshProUGUI my_text;

    public float GetPercentLostInhabitants()
    {
        return percentLostInhabitants;
    }

    public float GetPercentLostFood()
    {
        return percentLostFood;
    }

    public float GetPercentLostSouls()
    {
        return percentLostSouls;
    }

    private void Start()
    {
        my_text = GetComponentInChildren<TextMeshProUGUI>();
    }
}
