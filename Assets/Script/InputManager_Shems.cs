using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager_Shems : MonoBehaviour {

    private GameObject obj;
    [SerializeField]
    private GameObject mainUI;

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
            RaycastHit hit = new RaycastHit();
            Physics.Raycast(Camera.main.transform.position, ray.direction, out hit);
            if (hit.collider)
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.red, 100f);
                Debug.Log(hit.collider.name);
                obj = hit.collider.gameObject;
                //obj.GetComponent<Renderer>().material.shader = Shader.Find("Specular");
                //obj.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                if (obj.tag == "Building")
                {
                    Debug.Log("Click on building");
                    mainUI.GetComponent<UIBuildingsManagerMainGame_Lea>().OnBuildingInteraction(obj);

                }
                if(obj.tag == "FreeArea")
                {
                    Debug.Log("Click on free area");
                    mainUI.GetComponent<UIBuildingsManagerMainGame_Lea>().OnFreeAreaInteraction();
                }
                if (obj.tag == "Door")
                {
                    //TO DO 
                    //button when you click on a door
                }
            }


        }
    }
}
