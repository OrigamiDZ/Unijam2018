using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InputManagerGodCouncil_Shems : MonoBehaviour {

    private GameObject obj;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;
    // Use this for initialization
    public void HideText()
    {
        canvas.SetActive(false);
    } 

    public void YesPressed()
    {

    }
	void Start () {
        canvas.SetActive(false);
        noButton.onClick.AddListener(HideText);
        yesButton.onClick.AddListener(YesPressed);
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
                    canvas.SetActive(true);
                }
            }


        }
    }
}
