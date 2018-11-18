using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start () {
        Debug.Log(InputManagerGodCouncil_Shems.divinity);
        divinity = InputManagerGodCouncil_Shems.divinity;
        randomnumber = Random.Range(0, 10);
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
            if (mood == 0)
            {
                text.text = "Hahaha, bienvenu dans mon sanctuaire, jeune divinité. Je suis Zeus, le plus puissant des dieux." +
                    "Je te propose un marché que tu ne pourras pas refuser : apporte moi 100 âmes, et je conférai la grâce de ma précense à ton peuple." +
                    "Ces derniers seront ainsi plus...productifs. Qu'en dis-tu ?";
                YesChoice.GetComponentInChildren<Text>().text = "Payer 100 âmes";
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 1)
            {
                text.text = "Tiens donc, serait-ce notre chère nouvelle divinité qui fait de nouvelle vague ? " +
                    "Je te propose, en échange de 200 âmes, d'augmenter la fertilité de ton peuple.";
                YesChoice.GetComponentInChildren<Text>().text = "Payer 200 âmes";
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 2)
            {
                text.text = "Qui ose m'interrompre ??!! Maudit soit-tu, insolent lezard !!! Subis mon courroux misérable !";
                canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Vous perdez ??? âmes";
            }
        }

        if (divinity == 1)
        {
            //Freyja
            if (mood == 0)
            {
                text.text = "Bienvenue à toi dans mon jardin, jeune dieux. " +
                    "C'est avec plaisir que je t'offre mes services pour aider ton peuple à prospérer.";
                YesChoice.GetComponentInChildren<Text>().text = "Payer 50 âmes";
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 1)
            {
                text.text = "Comme c'est intéressant, j'allais justement me préparer pour visiter l'Amérique avec mes valeureux soldats." +
                    "Souhaites-tu que j'apporte mon aide à ton peuple ?";
                YesChoice.GetComponentInChildren<Text>().text = "Payer 100 âmes";
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 2)
            {
                text.text = "Lézard, tu arrives au mauvais moment. " +
                    "Toutefois, je peux consentir à t'apporter mon aide si tu parviens à m'y convaincre : 200 âmes, ni plus, ni moins !";
                YesChoice.GetComponentInChildren<Text>().text = "Payer 200 âmes";
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
        }

        if (divinity == 2)
        {
            //Osiris
            text.text = "C'est désert, le dieu est probablement occupé ailleurs ... mais vous trouvez quand même des âmes qui traînent dans le sanctuaire." +
                "Comme Vous le disez toujours, ce qui traîne n'appartient à personne, et il n'avait qu'à faire plus attention à ces dernières.";
            YesChoice.GetComponentInChildren<Text>().text = "Vous récupérez ??? âmes";
        }

        if (divinity == 3)
        {
            //Kronos, si non implémenté, bonus de souls
            text.text = "C'est désert, le dieu est probablement occupé ailleurs ... mais vous trouvez quand même des âmes qui traînent dans le sanctuaire." +
            "Comme Vous le disez toujours, ce qui traîne n'appartient à personne, et il n'avait qu'à faire plus attention à ces dernières.";
            YesChoice.GetComponentInChildren<Text>().text = "Vous récupérez ??? âmes";
        }

        if (divinity == 4)
        {
            //Quetzalcoatl
            if (mood == 0)
            {
                text.text = "Bienvenue à toi, petit. Je suis le plus puissant des dieux. " +
                    "Celui que les mortels craignent et respectent et que les dieux n'osent offenser. " +
                    "Je peux t'apporter mes connaissances en rituels, qu'en penses-tu ?";
                YesChoice.GetComponentInChildren<Text>().text = "Payer 100 âmes";
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 1)
            {
                text.text = "Je suis le serpent à plume, le plus puissant des dieux. " +
                    "Celui qui peut détruire des villes par ma présence seul. " +
                    "Je connais d'innombrable savoir, toi aussi, tu es intéressé par mon savoir milléniaire ?";
                YesChoice.GetComponentInChildren<Text>().text = "Payer 200 âmes";
                NoChoice.GetComponentInChildren<Text>().text = "Refuser l'offre";
            }
            if (mood == 2)
            {
                text.text = "Imposteur, comment oses-tu te présenter en ces lieux ! Subis mon courroux et tremble de terreur!";
                canvas.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
                NoChoice.GetComponentInChildren<Text>().text = "Vous perdez ??? âmes";
            }
        }

	}

    /* (vous perdez 50% de vos âmes)
     * 
     * (en cas de refus, -25%)
     * 
     * 
     * Osiris :
     * 
     * heureux : "Bienvenue à toi dans le royaume des morts, jeune divinité, ici, je juge l'âme des mortels, et leurs offrent éternelle jouissance, ou l'oubli. Nanmoins, je consens à t'envoyer des morts-vivants pour aider ton peuple à se développer contre 50 âmes.
     * 
     * Neutre : "La mort n'est jamais loin, mais elle garde toujours ses distances. Que viens-tu faire ici jeune divinité ? Souhaites-tu mon aide ? Ce sera 100 âmes."
     * 
     * Furieux : "Maudit soit Seth, Apophis et toutes ces engeances du mal, et toi lézard à plume, tu ne vaut pas mieux qu'eux, tu ferais mieux de partir avant que l'envie ne me prenne de t'écorcher vif"
     * 
     * 
     * 
     * 
     * */
	
	// Update is called once per frame
	void Update () {
		
	}
}
