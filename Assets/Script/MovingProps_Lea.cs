using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingProps_Lea : MonoBehaviour {
    public float speedX;
    public float speedY;
    public int dirX;
    public int dirY;
    private float posX;
    private float posY;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        posX = dirX * speedX;
        posY = dirY * speedY;
        transform.position += new Vector3(posX, posY, 0);
	}
}
