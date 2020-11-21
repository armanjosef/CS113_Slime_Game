using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{

    public GameObject player;
    public EnemySpawner spawner;
    public Vector3 scaleChange;

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(collision.gameObject);
        spawner.enemyCount -= 1;
        player.transform.localScale += scaleChange;
    }
}
