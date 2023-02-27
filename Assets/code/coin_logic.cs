using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coin_logic : MonoBehaviour
{
    public int coinValue = 1;
    public int chestValue = 10;
    public int enemyValue = 3;

    public int playerscore;
    public Text scoreText;

    public void addcoin()
    {
        playerscore += coinValue;
        scoreText.text = playerscore.ToString();
    }

    public void addchest()
    {
        playerscore += chestValue;
        scoreText.text = playerscore.ToString();
    }

    public void addenemy()
    {
        playerscore += enemyValue;
        scoreText.text = playerscore.ToString();
    }
}
