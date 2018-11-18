using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InputManagerGodCouncil_Shems : MonoBehaviour {

    private GameObject obj;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;

    public static int divinity;
    private float timer=4f;
    private bool beginTimer = false;
    // Use this for initialization
    public void HideText()
    {
        canvas.SetActive(false);
    } 

    public int GetDivinity()
    {
        return divinity;
    }

    public void YesPressed(GameObject gam)
    {
        beginTimer = true;
        gameObject.GetComponent<ZoomEffect_Shems>().setObj(gam);
        gameObject.GetComponent<ZoomEffect_Shems>().setZoom(true);
        gameObject.GetComponent<Fade_Shems>().BeginFade(1);
        divinity = gam.GetComponent<Door_Shems>().GetDivinity();
    }
	void Start () {
        canvas.SetActive(false);
        noButton.onClick.AddListener(HideText);
        yesButton.onClick.AddListener(() => YesPressed(obj));
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("escape pressed");
        }
        //Debug.Log(canvas.transform.position.x);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.transform.name);
                //Debug.Log(hit.transform.position.x);
                if (canvas.activeSelf == false)
                {
                    obj = hit.transform.gameObject;
                    if (obj.tag == "Door")
                    {
                        canvas.SetActive(true);
                        //transform.position.Set(0, 0, 0);
                        canvas.transform.GetChild(0).GetComponent<RectTransform>().anchorMin = new Vector2(0.5f + obj.transform.position.x / 40, 0.85f);
                        canvas.transform.GetChild(0).GetComponent<RectTransform>().anchorMax = new Vector2(0.5f + obj.transform.position.x / 40, 0.85f);
                    }
                }
            }


        }
        if (beginTimer)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
