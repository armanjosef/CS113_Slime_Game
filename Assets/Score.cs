using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highScoreText;
    public CollisionScript collision;
    public Vector3 initialScale;
    public int scoreNum;
    //public int highScoreNum;

    // Start is called before the first frame update
    void Start() {
        initialScale = collision.scaleChange;
        scoreNum = -9;
        //highScoreText.text = "0";
    }

    // Update is called once per frame
    void Update() {
        while (initialScale.x < collision.player.transform.localScale.x 
            && initialScale.y < collision.player.transform.localScale.y 
            && initialScale.z < collision.player.transform.localScale.z) {
            scoreNum += 1;
            initialScale += collision.scaleChange;
        }

        scoreText.text = scoreNum.ToString();

        //if (highScoreNum < scoreNum)
        //    highScoreNum = scoreNum;
    }
}
