using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{
    public void RetryGame(){
        SceneManager.LoadScene(PlayerPrefs.GetString("lastScene"));
    }

    public void QuitGame(){
        SceneManager.LoadScene("ui_start");

    }
}
