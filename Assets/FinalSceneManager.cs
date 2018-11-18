using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneManager : MonoBehaviour {

    private string final;

	// Use this for initialization
	void Start () {
        if (PlayerPrefs.HasKey("Final"))
        {
            final = PlayerPrefs.GetString("Final");
        }
        else
        {
            final = "Win";
            Debug.Log("final is not defined, default values used");
        }

        // TODO : launch video according to the string
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
