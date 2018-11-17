using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Shems : MonoBehaviour {

    [SerializeField]
    private Texture2D fadeOutTexture;
    [SerializeField]
    private float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;

	
}
