using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class JesusRaid2Manager_Aure : MonoBehaviour {


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

    [SerializeField]
    private GameObject introTextJesusBonus;
    [SerializeField]
    private GameObject introTextYouBonus;

    private float endTime;
    private bool gameOn;

    private float ourRessourceSent;
    private float enemyRessource;
    private float bonusMalus;

    // Use this for initialization
    void Start()
    {

        gameOn = false;
        if (countdown == 0)
        {
            Debug.Log("Countdown == 0");
        }

        textTime.text = "Time : " + gameDuration;

        if (PlayerPrefs.HasKey("raidVSJesusInhabitants"))
        {
            bonusMalus = PlayerPrefs.GetFloat("raidVSJesusInhabitants");
        }
        else
        {
            bonusMalus = 1;
            Debug.Log("bonusMalus is not defined, default values used");
        }

        if (PlayerPrefs.HasKey("ourSoulsRessourceSentFinal"))
        {
            ourRessourceSent = PlayerPrefs.GetFloat("ourSoulsRessourceSentFinal") * bonusMalus;
        }
        else
        {
            ourRessourceSent = 300;
            Debug.Log("ourSoulsRessourceSentFinal is not defined, default values used");
        }

        if (PlayerPrefs.HasKey("jesusSoulsRessourceFinal"))
        {
            enemyRessource = PlayerPrefs.GetFloat("jesusSoulsRessourceFinal");
        }
        else
        {
            enemyRessource = 300;
            Debug.Log("jesusSoulsRessourceFinal is not defined, default values used");
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
                PlayerPrefs.SetString("Final", "Win");
                gameOn = false;
                SceneManager.LoadScene(7);
            }
            if (slider.value <= slider.minValue)
            {
                StopCoroutine("SliderDecrease");
                PlayerPrefs.SetString("Final", "Lose");
                gameOn = false;
                SceneManager.LoadScene(7);

            }
            if (endTime < Time.time)
            {
                StopCoroutine("SliderDecrease");
                textTime.text = "Time : 0";
                if (slider.value >= (slider.maxValue - slider.minValue)/2)
                {
                    PlayerPrefs.SetString("Final", "Win");
                }
                else
                {
                    PlayerPrefs.SetString("Final", "Lose");

                }
                gameOn = false;
                SceneManager.LoadScene(7);
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
