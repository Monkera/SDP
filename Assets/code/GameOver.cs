using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public static bool gameOver = false;
    public GameObject gameOverUI;
    public string _MainMenu;
    public string _Level;   

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

            if (gameOver)
            {
                Retry();
                gameOver = false;
            }

    }

    public void Retry()
    {
        SceneManager.LoadScene(_Level);
        
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(_MainMenu);
    }
}
