using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{
    public Text highScoreNumTxt;

    // Update is called once per frame
    void Update()
    {
        highScoreNumTxt.text = HighScore.highScore.ToString();
    }
}
