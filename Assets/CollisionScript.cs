using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionScript : MonoBehaviour
{

    public GameObject player;
    public EnemySpawner spawner;
    public Vector3 scaleChange;
    public float seconds_before_reset;

    public Animator animator;
    //public Animation eating;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Enemy")
            return;

        Vector3 enemy = collision.gameObject.transform.localScale;
        if (enemy.x <= player.transform.localScale.x && enemy.y <= player.transform.localScale.y) {
            Destroy(collision.gameObject);
            spawner.enemyCount -= 1;
            player.transform.localScale += scaleChange;

            float x = animator.GetFloat("Horizontal");
            if (x < 0)
                animator.Play("Base Layer.Player_Eat_Left");
            else if (x > 0)
                animator.Play("Base Layer.Player_Eat_Right");
        } else {
            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine() {
        animator.Play("Base Layer.Player_Death");
        yield return new WaitForSeconds(seconds_before_reset);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
