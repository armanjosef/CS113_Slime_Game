using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject player;
    public Text timeText;
    private float timeAlloted;
    private Player_Movement movement;
    private bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        timeAlloted = 30;
        movement = GetComponent<Player_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning == true)
        {
            if (timeAlloted > 0)
            {
                timeAlloted -= Time.deltaTime;
                DisplayTime(timeAlloted);
            }
            else
            {
                timeAlloted = 0;
                movement.moveSpeed = 0f; // stop movement of player
                isRunning = false;
            }
        }
    }

    void DisplayTime(float time)
    {
        time += 1;
        float seconds = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}", seconds);
    }
}
