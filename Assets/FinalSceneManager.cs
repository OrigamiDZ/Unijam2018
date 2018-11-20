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
            final = "WinAJ";
            Debug.Log("final is not defined, default values used");
        }

        if (final.Equals("WinAJ"))
        {
            winAJ.Play();
        }
        else if (final.Equals("LoseAJ"))
        {
            loseAJ.Play();
        }
        else if (final.Equals("Lose"))
        {
            loser.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
