using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject rangeEnemy;
    public int xPos_1, xPos_2, zPos_1, zPos_2;
    public int enemyCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (GamePlayController.instance.phase1 == true
        && enemyCount == 0)
        {
            enemyCount++;
            xPos_1 = -38;
            zPos_1 = 204;
            xPos_2 = 35;
            zPos_2 = 225;
            Instantiate(rangeEnemy, new Vector3(xPos_1, 8, zPos_1), Quaternion.identity);
            Instantiate(rangeEnemy, new Vector3(xPos_2, 8, zPos_2), Quaternion.identity);
        }

        if (GamePlayController.instance.phase2 == true
        && enemyCount == 1)
        {
            enemyCount++;
            xPos_1 = -42;
            zPos_1 = 290;
            xPos_2 = 36;
            zPos_2 = 275;
            Instantiate(rangeEnemy, new Vector3(xPos_1, 8, zPos_1), Quaternion.identity);
            Instantiate(rangeEnemy, new Vector3(xPos_2, 8, zPos_2), Quaternion.identity);
        }
    }
}
