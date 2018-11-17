using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager_Shems : MonoBehaviour {

    private GameObject obj;
    [SerializeField]
    private Camera cam;
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
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit != null && hit.collider != null)
            {
                Debug.Log(hit.transform.name);
                obj = hit.transform.gameObject;
                //obj.GetComponent<Renderer>().material.shader = Shader.Find("Specular");
                //obj.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                if (obj.tag == "Building")
                {
                    Debug.Log("Click on building");
                    mainUI.GetComponent<UIBuildingsManagerMainGame_Lea>().OnBuildingInteraction(obj);

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
