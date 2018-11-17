using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerGodCouncil_Shems : MonoBehaviour {

    private GameObject obj;
    [SerializeField]
    private GameObject canvas;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("escape pressed");
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);
                obj = hit.transform.gameObject;
                if (obj.tag == "Door")
                {
                    Instantiate(canvas, obj.transform);
                }
            }


        }
    }
}
