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
    private int lostInhabitants;

    [SerializeField]
    private int lostFood;

    [SerializeField]
    private int lostSouls;

    private TextMeshProUGUI my_text;

    public int GetLostInhabitants()
    {
        return lostInhabitants;
    }

    public int GetLostFood()
    {
        return lostFood;
    }

    public int GetLostSouls()
    {
        return lostSouls;
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
