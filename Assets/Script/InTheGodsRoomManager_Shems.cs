using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InTheGodsRoomManager_Shems : MonoBehaviour {
    /* enum God
    {
        Zeus, Freyja, Osiris, Quetzalcoatl, Kronos
    };*/
    // Use this for initialization
    private int divinity;
    private int mood;
    private int randomnumber;
    [SerializeField]
    private GameObject canvas;
    private Text text;
    [SerializeField]
    private Button YesChoice;
    [SerializeField]
    private Button NoChoice;
    [SerializeField]
    private GameObject Zeus;
    [SerializeField]
    private GameObject Freyja;
    [SerializeField]
    private GameObject Osiris;
    private float bonusSoulsProduction;
    private float bonusFood;
    private float bonusFertility;
    private int currentSouls;

    public void YesPressed()
    {
        //Zeus
        if (divinity == 0)
        {
            if (mood == 0)
            {
                PlayerPrefs.SetFloat("bonusFertility", 0.4f);
                PlayerPrefs.SetInt("souls", currentSouls - 10);
            }
            if (mood == 1)
            {
                PlayerPrefs.SetFloat("bonusFertility", 0.3f);
                PlayerPrefs.SetInt("souls", currentSouls - 10);
                
            }
            if (mood == 2)
            {

                PlayerPrefs.SetInt("souls", (int)((currentSouls-5)*0.55));
                
            }
        }
        //Freyja
        if (divinity == 1)
        {
            if (mood == 0)
            {
                PlayerPrefs.SetFloat("bonusFood", 0.4f);
                PlayerPrefs.SetInt("souls", currentSouls - 10);
            }
            if (mood == 1)
            {
                PlayerPrefs.SetFloat("bonusFood", 0.3f);
                PlayerPrefs.SetInt("souls", currentSouls - 10);
            }
            if (mood == 2)
            {
                PlayerPrefs.SetFloat("bonusFood", 0.3f);
                PlayerPrefs.SetInt("souls", currentSouls - 20); 
            }
        }
        //Quetzalcoatl
        if (divinity == 4)
        {
            if (mood == 0)
            {
                PlayerPrefs.SetFloat("bonusSoulsProduction", 0.5f);
                PlayerPrefs.SetInt("souls", currentSouls - 10);
            }
            if (mood == 1)
            {
                PlayerPrefs.SetFloat("bonusSoulsProduction", 0.25f);
                PlayerPrefs.SetInt("souls", currentSouls - 10);
            }
            if (mood == 2)
            {

                PlayerPrefs.SetInt("souls", (int)((currentSouls - 10) * 0.75));
            }
        }
        //not done still
        else
        {
            PlayerPrefs.SetInt("souls", (int)(currentSouls + (randomnumber / 3) + 1));
        }
        Debug.Log("1");
        SceneManager.LoadScene(1);
    }
    public void NoPressed()
    {

        //Zeus
        if (divinity == 0)
        {
            if (mood == 0)
            {
            }
            if (mood == 1)
            {
            }
            if (mood == 2)
            {
                PlayerPrefs.SetInt("souls", (int)((currentSouls - 5) * 0.55));
            }
        }
        //Freyja
        if (divinity == 1)
        {
            if (mood == 0)
            {
            }
            if (mood == 1)
            {
            }
            if (mood == 2)
            {
                PlayerPrefs.SetInt("souls", (int)((currentSouls - 2) * 0.75));
            }
        }
        //Quetzalcoatl
        if (divinity == 4)
        {
            if (mood == 0)
            {
            }
            if (mood == 1)
            {
            }
            if (mood == 2)
            {
                PlayerPrefs.SetInt("souls", (int)((currentSouls - 10) * 0.75));
            }
        }
        //not done still
        else
        {
        }
        
        SceneManager.LoadScene(1);
    }

    void Start () {
        //Debug.Log(InputManagerGodCouncil_Shems.divinity);
        divinity = InputManagerGodCouncil_Shems.divinity;
        Zeus.SetActive(false);
        Osiris.SetActive(false);
        Freyja.SetActive(false);
        canvas.SetActive(false);
        //divinity = 0;
        bonusFood = 0;
        bonusSoulsProduction = 0;
        bonusFertility = 0;
        NoChoice.onClick.AddListener(NoPressed);
        YesChoice.onClick.AddListener(YesPressed);
        randomnumber = Random.Range(0, 10);
        currentSouls = PlayerPrefs.GetInt("souls");
        
        text = canvas.transform.GetChild(0).GetComponent<Text>();
        if (randomnumber < 1)
        {
            //mood =0 means that the god is angry
            mood = 0;
        }
        else if (randomnumber < 7)
        {
            //mood=1 means that the god is neutral
            mood = 1;
        }
        else
        {
            //mood=2 means that the god is happy
            mood = 2;
        }

        if (divinity == 0)
        {
            //Zeus
            Zeus.SetActive(true);
            if (mood == 0)
            {
                text.text = "Hahaha, bienvenu dans mon sanctuaire, jeune divinité. Je suis Zeus, le plus puissant des dieux." +
                    "Je te propose un marché que tu ne pourras pas refuser : apporte moi 100 âmes, et je conférai la grâce de ma précense à ton peuple." +
                    "Ces derniers seront ainsi plus...productifs. Qu'en dis-tu ?";
                if (currentSouls >10)
                    YesChoice.GetComponentInChildren<Text>().text = "Payer 10 âmes";
                else
                    canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 1)
            {
                text.text = "Tiens donc, serait-ce notre chère nouvelle divinité qui fait de nouvelle vague ? " +
                    "Je te propose, en échange de 15 âmes, d'augmenter la fertilité de ton peuple.";
                if (currentSouls > 10)
                    YesChoice.GetComponentInChildren<Text>().text = "Payer 10 âmes";
                else
                    canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 2)
            {
                text.text = "Qui ose m'interrompre ??!! Maudit sois-tu, insolent lezard !!! Subis mon courroux misérable !";
                canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Vous perdez " + (currentSouls - (int)((currentSouls - 5) * 0.55)) + " âmes";
            }
        }

        if (divinity == 1)
        {
            //Freyja
            Freyja.SetActive(true);
            if (mood == 0)
            {
                text.text = "Bienvenue à toi dans mon jardin, jeune dieux. " +
                    "C'est avec plaisir que je t'offre mes services pour aider ton peuple à prospérer.";
                if (currentSouls > 10)
                    YesChoice.GetComponentInChildren<Text>().text = "Payer 10 âmes";
                else
                    canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 1)
            {
                text.text = "Comme c'est intéressant, j'allais justement me préparer pour visiter l'Amérique avec mes valeureux soldats." +
                    "Souhaites-tu que j'apporte mon aide à ton peuple ?";
                if(currentSouls > 10)
                    YesChoice.GetComponentInChildren<Text>().text = "Payer 10 âmes";
                else
                    canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 2)
            {
                text.text = "Lézard, tu arrives au mauvais moment. " +
                    "Toutefois, je peux consentir à t'apporter mon aide si tu parviens à m'y convaincre : 20 âmes, ni plus, ni moins !";
                if (currentSouls > 20)
                    YesChoice.GetComponentInChildren<Text>().text = "Payer 20 âmes";
                else
                    canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre et perdre "+ (currentSouls-(int)(currentSouls-2)*0.75) +"âmes.";
            }
        }

        if (divinity == 2)
        {
            //Osiris
            text.text = "C'est désert, le dieu est probablement occupé ailleurs ... mais vous trouvez quand même des âmes qui traînent dans le sanctuaire." +
                "Comme Vous le disez toujours, ce qui traîne n'appartient à personne, et il n'avait qu'à faire plus attention à ces dernières.";
            YesChoice.GetComponentInChildren<Text>().text = "Vous récupérez" + (int)((randomnumber / 3) + 1) + "âmes";
            canvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

        if (divinity == 3)
        {
            //Kronos, si non implémenté, bonus de souls
            text.text = "C'est désert, le dieu est probablement occupé ailleurs ... mais vous trouvez quand même des âmes qui traînent dans le sanctuaire." +
            "Comme Vous le disez toujours, ce qui traîne n'appartient à personne, et il n'avait qu'à faire plus attention à ces dernières.";
            YesChoice.GetComponentInChildren<Text>().text = "Vous récupérez " + (int)((randomnumber / 3) + 1) + " âmes";
            canvas.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        }

        if (divinity == 4)
        {
            //Osiris
            Osiris.SetActive(true);
            if (mood == 0)
            {
                text.text = "Bienvenue à toi, petit. Je suis le Osiris, le dieu des Morts. " +
                    "Celui que les mortels craignent et respectent. " +
                    "Je peux t'apporter mes connaissances en rituels, qu'en penses-tu ?";
                if (currentSouls > 10)
                    YesChoice.GetComponentInChildren<Text>().text = "Payer 10 âmes";
                else
                    canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 1)
            {
                text.text = "Mon frère Seth m'a trahi, mais même cela n'a suffit à m'arréter. " +
                    "Mes connsaissances sur les arts mystiques sont sans limite, souhaites-tu que je t'en face parte d'une fraction ?";
                if (currentSouls > 10)
                    YesChoice.GetComponentInChildren<Text>().text = "Payer 10 âmes";
                else
                    canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 2)
            {
                text.text = "Maudits Seth, Apophis et toutes ces engeances du Mal! " +
                    "Quitte cette abode sacrée avant que je ne t'écorche vif, vile créature!";
                canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Vous perdez " + (currentSouls-(int)((currentSouls - 10) * 0.75)) + " âmes.";
            }
        }
        canvas.SetActive(true);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            {
            }
        }
	}
}
