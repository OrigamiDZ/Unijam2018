using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    
    public void StartButton()
    {
        PlayerPrefs.SetString("IsItDebut", "Yes");
        SceneManager.LoadScene(1);
    }
}
