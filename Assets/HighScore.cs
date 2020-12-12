using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public CollisionScript collision;
    public static int highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.scores > highScore)
        {
            highScore = collision.scores;
            //Debug.Log("High score: " + highScore.ToString());
        }
    }
}
