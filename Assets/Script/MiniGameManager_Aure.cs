using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject endText;

    private float endTime;
    private bool gameOn;

    private float ourRessourceSent;
    private float enemyRessource;

    // Use this for initialization
    void Start () {
        gameOn = false;
        endText.SetActive(false);
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
            }
            if (slider.value >= slider.maxValue)
            {
                StopCoroutine("SliderDecrease");
                int people = PlayerPrefs.GetInt("people");
                PlayerPrefs.SetInt("people", (int)(1.5*people) + 1);
                gameOn = false;
                endText.SetActive(true);
                endText.GetComponentInChildren<TextMeshProUGUI>().text = "Vous avez erradiqué l'envahisseur, vous gagnez " + people + " prisonniers.";
            }
            if (slider.value <= slider.minValue)
            {
                StopCoroutine("SliderDecrease");
                int people = PlayerPrefs.GetInt("people");
                PlayerPrefs.SetInt("people", (int)(0.5 * people) + 1);
                gameOn = false;
                endText.SetActive(true);
                endText.GetComponentInChildren<TextMeshProUGUI>().text = "La moitié de vos habitants, soit " + people + " personnes, ont été fait prisonniers, êtes-vous sûr d'être un dieu ?";
            }
            if (endTime < Time.time)
            {
                StopCoroutine("SliderDecrease");
                textTime.text = "Time : 0";
                int people = PlayerPrefs.GetInt("people");
                int newPopulation = (int)(1.0f / (slider.minValue + slider.maxValue) * slider.value + 1.5f * slider.minValue + 0.5f * slider.maxValue) * people;
                int peopleBalance = newPopulation - people;

                PlayerPrefs.SetInt("people", newPopulation);
                gameOn = false;
                endText.SetActive(true);

                if (peopleBalance < 0 )
                {
                    endText.GetComponentInChildren<TextMeshProUGUI>().text = -peopleBalance + " de vos habitants ont été fait prisonniers, je doute fort qu'ils s'en sortent ...";
                }
                else if (peopleBalance == 0)
                {
                    endText.GetComponentInChildren<TextMeshProUGUI>().text = "Match nul, aucune pertes ! (Ni gains remarque)";
                }
                else
                {
                    endText.GetComponentInChildren<TextMeshProUGUI>().text = "Vous avez réussis à faire quelques prisonniers, vous possédez " + peopleBalance  + " nouveaux habitants.";
                }
            }
        }
    }

    public void ReturnGame()
    {
        SceneManager.LoadScene(1);
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
