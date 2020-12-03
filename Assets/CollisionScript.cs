using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public GameObject player;
    public EnemySpawner spawner;
    public Vector3 scaleChange;
    //public Animation eating;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag != "Enemy")
            return;

        Vector3 enemy = collision.gameObject.transform.localScale;
        if (enemy.x <= player.transform.localScale.x && enemy.y <= player.transform.localScale.y) {
            Destroy(collision.gameObject);
            spawner.enemyCount -= 1;
            player.transform.localScale += scaleChange;
            //eating.Play();
        }
    }
}
