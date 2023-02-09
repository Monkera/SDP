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

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        if (gameOver)
        {
            gameOver = false;
            Retry();
        }

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitGame()
    {
        SceneManager.LoadScene(_MainMenu);
    }
}
