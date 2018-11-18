using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodHead_Lea : MonoBehaviour {

    public Sprite lowSprite;
    public Sprite mediumSprite;
    public Sprite highSprite;
    public GameObject City;
    public int lowThreshold;
    public int highThreshold;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(City.GetComponent<CityShems>().Get_souls() < lowThreshold)
        {
            GetComponent<Image>().sprite = lowSprite;
        }
        else if(City.GetComponent<CityShems>().Get_souls() > highThreshold)
        {
            GetComponent<Image>().sprite = highSprite;
        }
        else
        {
            GetComponent<Image>().sprite = mediumSprite;
        }
	}
}
