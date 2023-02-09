using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScenesOptions : MonoBehaviour
{
    public void Settings(){
        SceneManager.LoadScene("SettingsMenu2");
    }
    public void Play(){
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }
    public void Quit(){
        SceneManager.LoadScene("ui_start");
    }
}
