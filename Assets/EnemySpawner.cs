using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //public GameObject enemySlime;
    public GameObject playerSlime;
    public GameObject[] enemySlimes = new GameObject[6];
    public int x_range, y_range;
    public int enemyCount = 0;
    public int maxEnemyCount = 10;
    public float wait_time = 0.1f;
    public int scale_effect = 1;

    private int xPos, yPos;
    private int x_limit = 10, y_limit = 8;
    //private float next_time = 0;

    // Start is called before the first frame update
    void Start() {
        InvokeRepeating("EnemyDrop", 0, wait_time);
    }

    // Update is called once per frame
    void Update() {}

    bool IsWithinPlayerRange(int ex, int ey) { //, float px, float py) {
        Rigidbody2D playerRB = playerSlime.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        float px = playerRB.position.x;
        float py = playerRB.position.y;

        return Mathf.Abs(ex - px) <= x_limit && Mathf.Abs(ey - py) <= y_limit;
    }

    void EnemyDrop() {
        if (enemyCount < maxEnemyCount) {
            do {
                xPos = Random.Range(-x_range, x_range);
                yPos = Random.Range(-y_range, y_range);
            } while (IsWithinPlayerRange(xPos, yPos)); //, player_xPos, player_yPos));

            int enemy_index = Random.Range(0, enemySlimes.Length);
            int enemy_scale = Random.Range(-1, 2);
            Debug.Log(enemy_scale);
            Vector3 x = playerSlime.transform.localScale;
            
            GameObject new_enemy = Instantiate(enemySlimes[enemy_index], new Vector3(xPos, yPos, -1), Quaternion.identity);
            new_enemy.transform.localScale = x + new Vector3(enemy_scale / 10f, enemy_scale / 10f, 0);
            enemyCount += 1;

        //    yield return new WaitForSeconds(wait_time);
        }
    }
}
