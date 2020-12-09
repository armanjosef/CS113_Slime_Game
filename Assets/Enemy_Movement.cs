using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float towardsSpeed;
    public float awaySpeed;
    public float lineOfSite;
    public Animator animator;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update(){
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSite) {
            if (transform.localScale.x > player.transform.localScale.x && transform.localScale.y > player.transform.localScale.y) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, towardsSpeed * Time.deltaTime);
                //Debug.Log(transform.position);
            }
            else {
                Vector2 runAwayPosition = transform.position - player.position;
                transform.position = Vector2.MoveTowards(transform.position, player.position, -1 * awaySpeed * Time.deltaTime); ;
            }
                
            animator.SetFloat("Horizontal", transform.position.x);
            animator.SetFloat("Vertical", transform.position.y);
            animator.SetFloat("Speed", transform.position.sqrMagnitude);
        } else {
            animator.SetFloat("Speed", 0);
        }
   }
}
