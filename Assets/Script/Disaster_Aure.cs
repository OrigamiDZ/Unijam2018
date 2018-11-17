using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Disaster_Aure : MonoBehaviour {

    [SerializeField]
    private string textExplanatory;

    [SerializeField]
    private int deltaHabitants;

    [SerializeField]
    private int deltaFood;

    [SerializeField]
    private int deltaSouls;

    private TextMeshProUGUI my_text;

    private void Start()
    {
        my_text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        my_text.SetText(textExplanatory);
    }

}
