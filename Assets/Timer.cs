using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject player;
    public Text timeText;
    public float timeAlloted;
    private Player_Movement movement;
    private bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
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
        else
        {
            movement.moveSpeed = 0f;
            player.GetComponent<Animator>().enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void DisplayTime(float time)
    {
        time += 1;
        time = Mathf.FloorToInt(time);
        timeText.text = time.ToString();
    }
}
