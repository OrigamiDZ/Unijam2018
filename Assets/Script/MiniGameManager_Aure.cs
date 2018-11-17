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
    private float finalScore;
    private bool gameOn;

    // Use this for initialization
    void Start () {
        gameOn = false;
        if (countdown == 0)
        {
            Debug.Log("Countdown == 0");
        }

        textTime.text = "Time : " + gameDuration;
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
                slider.value++;
            }
            if (slider.value >= slider.maxValue)
            {
                StopCoroutine("SliderDecrease");
                gameOn = false;
                finalScore = slider.maxValue;
                Debug.Log("You win");
            }
            if (slider.value <= slider.minValue)
            {
                StopCoroutine("SliderDecrease");
                gameOn = false;
                finalScore = 0;
                Debug.Log("You lose");
            }
            if (endTime < Time.time)
            {
                StopCoroutine("SliderDecrease");
                textTime.text = "Time : 0";
                finalScore = slider.value;
                gameOn = false;
                Debug.Log("You lose : " + finalScore);
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
            slider.value -= 0.1f;
            Debug.Log(slider.value);
        }
    }
}
