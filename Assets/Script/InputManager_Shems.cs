using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager_Shems : MonoBehaviour {

    private GameObject obj;
    [SerializeField]
    private GameObject MainUI;
    [SerializeField]
    private Camera camera;

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
            Ray2D ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast( camera.transform.position, Input.mousePosition);

            if (Physics2D.Raycast(hit, ray)
            {
                Debug.Log(hit.transform.name);
                obj = hit.transform.gameObject;
                //obj.GetComponent<Renderer>().material.shader = Shader.Find("Specular");
                //obj.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                if (obj.tag == "Building")
                {
                    Debug.Log("Click on building");
                    MainUI.GetComponent<UIBuildingsManagerMainGame_Lea>().OnBuildingInteraction(obj);
                }
            }


        }
    }
}
