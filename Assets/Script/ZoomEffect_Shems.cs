using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomEffect_Shems : MonoBehaviour {


    [SerializeField]
    private GameObject obj;
    [SerializeField]
    private float speedRotate = 120;
    [SerializeField]
    private GameObject cam;
    private bool zoom = false;
    private Vector3 center;
	// Use this for initialization
	void Start () {
        center = obj.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
        {
            zoom = true;
            gameObject.GetComponent<Fade_Shems>().BeginFade(1);

        }
        if (zoom == true)
        {
            
            if (cam.transform.position.z < center.z)
            {
                //rotate of the cam at the speedRotate speed on the Z axis with a transition toward an object
                cam.transform.Rotate(Vector3.forward, Time.deltaTime * speedRotate);
                cam.transform.position += (center - cam.transform.position)*Time.deltaTime*3;
            }
        }
	}
}
