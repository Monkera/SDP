using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settingsmain(){
        SceneManager.LoadScene("SettingsMenu_main");
    }

    public void Backtomain(){
        SceneManager.LoadScene("ui_start");

    }
}
