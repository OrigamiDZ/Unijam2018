using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager_Shems : MonoBehaviour {

    private GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
        {
            Debug.Log("escape pressed");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);
                obj = hit.transform.gameObject;
                //obj.GetComponent<Renderer>().material.shader = Shader.Find("Specular");
                //obj.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                if (obj.tag == "Building")
                {
                    //TO DO
                    //modify the bottom of the screen accroding to the building
                }

                if (obj.tag == "Freearea")
                {
                    //TO DO
                    //modify the bottom of the screen to follow the patern etablished
                }
            }


        }
    }
}
