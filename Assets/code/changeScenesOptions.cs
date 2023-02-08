using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenesOptions : MonoBehaviour
{
    public void Settings(){
        SceneManager.LoadScene("SettingsMenu");
    }
    public void Play(){
        SceneManager.LoadScene("testtitle2jann");
    }
    public void Quit(){
        SceneManager.LoadScene("ui_start");
    }
}
