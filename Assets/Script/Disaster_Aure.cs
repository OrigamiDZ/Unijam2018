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
    private int percentLostInhabitants;

    [SerializeField]
    private int percentLostFood;

    [SerializeField]
    private int percentLostSouls;

    private TextMeshProUGUI my_text;

    public int GetPercentLostInhabitants()
    {
        return percentLostInhabitants;
    }

    public int GetPercentLostFood()
    {
        return percentLostFood;
    }

    public int GetPercentLostSouls()
    {
        return percentLostSouls;
    }

    private void Start()
    {
        my_text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        my_text.SetText(textExplanatory);
    }

}
