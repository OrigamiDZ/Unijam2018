using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsConcil_Shems : MonoBehaviour {

    private int number_of_door;
    private float frustumHeight;
    [SerializeField]
    private float distance;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject camera;
    enum God
    {
        Zeus, Hapi, Hades, Kronos, Quetzalcoatl
    };
    //enum God { Zeus, Hapi, Hades, Kronos, Quetzalcoatl, Thor, Odin, Osiris, Amaterasu, Isis };
    // Use this for initialization
    void Start () {
        number_of_door = Random.Range(3, 6);
        frustumHeight = 2.0f * distance * Mathf.Tan(camera.GetComponent<Camera>().fieldOfView * 0.5f * Mathf.Deg2Rad);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
