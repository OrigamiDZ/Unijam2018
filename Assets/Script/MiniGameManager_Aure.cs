using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class MiniGameManager_Aure : MonoBehaviour {

    [SerializeField]
    private int countdown;

    [SerializeField]
    private float gameDuration;

    [SerializeField]
    GameObject startText;

    [SerializeField]
    Slider slider;

    [SerializeField]
    private TextMeshProUGUI textCountdown;

    [SerializeField]
    private TextMeshProUGUI textTime;

    private float endTime;
    private bool gameOn;

    [SerializeField]
    private float ourRessourceSent;
    [SerializeField]
    private float enemyRessource;

    // Use this for initialization
    void Start () {
        gameOn = false;
        if (countdown == 0)
        {
            Debug.Log("Countdown == 0");
        }

        textTime.text = "Time : " + gameDuration;

        if (PlayerPrefs.HasKey("ourRessourceSent"))
        {
            ourRessourceSent = PlayerPrefs.GetFloat("ourRessourceSent");
        }
        else
        {
            ourRessourceSent = 300;
            Debug.Log("ourRessourceSent is not defined, default values used");
        }

        if (PlayerPrefs.HasKey("enemyRessource"))
        {
            enemyRessource = PlayerPrefs.GetFloat("enemyRessource");
        }
        else
        {
            enemyRessource = 300;
            Debug.Log("enemyRessource is not defined, default values used");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //countdown 
        if (countdown > 0)
        {
            textCountdown.text = countdown.ToString();
        }
        else if (countdown == 0)
        {
            textCountdown.text = "";
            StopCoroutine("Countdown");
            StartCoroutine("SliderDecrease");
            endTime = Time.time + gameDuration;
            gameOn = true;
            countdown--;
        }

        if (gameOn)
        {
            textTime.text = "Time : " + (endTime - Time.time);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                slider.value = slider.value + ourRessourceSent/enemyRessource;
                Debug.Log(ourRessourceSent / enemyRessource);
            }
            if (slider.value >= slider.maxValue)
            {
                StopCoroutine("SliderDecrease");
                PlayerPrefs.SetFloat("finalScore", slider.maxValue);
                gameOn = false;
            }
            if (slider.value <= slider.minValue)
            {
                StopCoroutine("SliderDecrease");
                PlayerPrefs.SetFloat("finalScore", slider.minValue);
                gameOn = false;
            }
            if (endTime < Time.time)
            {
                StopCoroutine("SliderDecrease");
                textTime.text = "Time : 0";
                PlayerPrefs.SetFloat("finalScore", slider.value);
                gameOn = false;
            }
        }
    }

    public void StartMiniGame()
    {
        startText.SetActive(false);
        StartCoroutine("Countdown");
    }

    IEnumerator Countdown()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            countdown--;
        }
    }

    IEnumerator SliderDecrease()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            slider.value = slider.value -enemyRessource/ourRessourceSent/10;
        }
    }
}
