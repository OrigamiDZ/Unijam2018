using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingForeground_Lea : MonoBehaviour {
    public GameObject sprite1;
    public GameObject sprite2;
    public GameObject startPos;
    public GameObject endPos;

    private void Update()
    {
        if(sprite1.transform.position.x >= endPos.transform.position.x)
        {
            sprite1.transform.position = startPos.transform.position;
        }
        if (sprite2.transform.position.x >= endPos.transform.position.x)
        {
            sprite2.transform.position = startPos.transform.position;
        }
    }
}
