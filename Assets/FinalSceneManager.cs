using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FinalSceneManager : MonoBehaviour {

    private string final;
    public VideoPlayer winAJ;
    public VideoPlayer loseAJ;
    public VideoPlayer loser;

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
        /*
         * si win contre jesus -> winAJ.Play();
         * si perd conter jesus -> loseAJ.Play();
         * sinon -> loser.Play();
         */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
