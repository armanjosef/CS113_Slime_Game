using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemySlime;
    public GameObject playerSlime;
    public int x_range, y_range;
    public int maxEnemyCount = 10;

    private int xPos, yPos;
    private int enemyCount = 0;
    private int x_limit = 10, y_limit = 8;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    void Update() {
        if (enemyCount < maxEnemyCount)
            StartCoroutine(EnemyDrop());
    }

    bool IsWithinPlayerRange(int ex, int ey) { //, float px, float py) {
        Rigidbody2D playerRB = playerSlime.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        float px = playerRB.position.x;
        float py = playerRB.position.y;

        return Mathf.Abs(ex - px) <= x_limit && Mathf.Abs(ey - py) <= y_limit;
    }

    IEnumerator EnemyDrop() {
        //while (enemyCount < 10) {
            do {
                xPos = Random.Range(-x_range, x_range);
                yPos = Random.Range(-y_range, y_range);
            } while (IsWithinPlayerRange(xPos, yPos)); //, player_xPos, player_yPos));

            Instantiate(enemySlime, new Vector2(xPos, yPos), Quaternion.identity);
            enemyCount += 1;

            yield return new WaitForSeconds(0.1f);
        //}
    }
}
