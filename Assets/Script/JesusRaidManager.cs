using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JesusRaidManager : MonoBehaviour {

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

    private float ourRessourceSent;
    private float enemyRessource;

    // Use this for initialization
    void Start()
    {
        gameOn = false;
        if (countdown == 0)
        {
            Debug.Log("Countdown == 0");
        }

        textTime.text = "Time : " + gameDuration;

        if (PlayerPrefs.HasKey("ourRessourceSentFinal"))
        {
            ourRessourceSent = PlayerPrefs.GetFloat("ourRessourceSentFinal");
        }
        else
        {
            ourRessourceSent = 300;
            Debug.Log("ourRessourceSentFinal is not defined, default values used");
        }

        if (PlayerPrefs.HasKey("jesusInahibitantsRessourceFinal"))
        {
            enemyRessource = PlayerPrefs.GetFloat("jesusInahibitantsRessourceFinal");
        }
        else
        {
            enemyRessource = 300;
            Debug.Log("jesusInahibitantsRessourceFinal is not defined, default values used");
        }
    }

    // Update is called once per frame
    void Update()
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
                slider.value = slider.value + ourRessourceSent / enemyRessource;
            }
            if (slider.value >= slider.maxValue)
            {
                StopCoroutine("SliderDecrease");
                PlayerPrefs.SetFloat("raidVSJesusInhabitants", 0.5f);
                gameOn = false;
                SceneManager.LoadScene(6);
            }
            if (slider.value <= slider.minValue)
            {
                StopCoroutine("SliderDecrease");
                PlayerPrefs.SetFloat("raidVSJesusInhabitants", 1.5f);
                gameOn = false;
                SceneManager.LoadScene(6);
            }
            if (endTime < Time.time)
            {
                StopCoroutine("SliderDecrease");
                textTime.text = "Time : 0";
                float raidVSJesusInhabitants = (1.0f / (slider.minValue + slider.maxValue)) * slider.value + 1.5f*slider.minValue + 0.5f*slider.maxValue;
                PlayerPrefs.SetFloat("raidVSJesusInhabitants", raidVSJesusInhabitants);
                gameOn = false;
                SceneManager.LoadScene(6);

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
        while (true)
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
            slider.value = slider.value - enemyRessource / ourRessourceSent / 10;
        }
    }
}
