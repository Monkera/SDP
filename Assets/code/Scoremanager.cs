using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoremanager : MonoBehaviour
{
    public TMP_Text textscore;
    public float score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0f;
        textScore.text = score.ToString() + " POINTS";
    }

    // Update is called once per frame
    void Update()
    {
       textScore.text = score.ToString() + " POINTS"; 
    }
}
