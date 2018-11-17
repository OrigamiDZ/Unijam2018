using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsCouncil_Shems : MonoBehaviour {

    private int number_of_door;
    //frustumWidth is the width of the scenary viewed by the camera at the distance distance
    private float frustumWidth;
    [SerializeField]
    private float distance;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject cam;
    //private int[] array;
    private GameObject gam;
    private Transform trans;
    enum God
    {
        Zeus, Hapi, Hades, Kronos, Quetzalcoatl
    };
    //enum God { Zeus, Hapi, Hades, Kronos, Quetzalcoatl, Thor, Odin, Osiris, Amaterasu, Isis };
    // Use this for initialization
    void Start () {
        trans = transform;
        number_of_door = Random.Range(3, 6);

        frustumWidth = 2.0f * distance * Mathf.Tan(cam.GetComponent<Camera>().fieldOfView * 0.5f * Mathf.Deg2Rad) * cam.GetComponent<Camera>().aspect;

        for (int i=0; i<number_of_door; i++)
        {
            gam = (GameObject)Instantiate(door, new Vector3(-frustumWidth + ((2.0f * i + 1) * frustumWidth / (number_of_door)), 0, distance), transform.rotation);
            gam.GetComponent<Door_Shems>().SetDivinity((int)Random.Range(0, 5));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
