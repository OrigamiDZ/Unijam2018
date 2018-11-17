using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Shems : MonoBehaviour {
    
    private Texture2D fadeOutTexture;
    private float fadeSpeed = 0.2f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

    void Start ()
    {
        fadeOutTexture = new Texture2D(1, 1);
        fadeOutTexture.SetPixel(0, 0, Color.black);
        fadeOutTexture.Apply();
    }

	void  OnGUI ()
    {
        
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        // clampf the value of alpha between 0 and 1 since GUI.color use value between this interval
        alpha = Mathf.Clamp01(alpha);

        //set the alpha avalue
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth; // make the black texture render on top
        //draw the texture to fit the whole screeen area
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }


    public float BeginFade (int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
}
