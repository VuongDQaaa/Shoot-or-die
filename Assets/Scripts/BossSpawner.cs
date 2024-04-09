using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private int xPos, Zpos;
    private bool enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GamePlayController.instance.stage3 == true && enemyCount == false)
        {
            enemyCount = true;
            xPos = 1;
            Zpos = 437;
            Instantiate(boss, new Vector3(xPos, 12, Zpos), Quaternion.identity);
        }
        
    }
}
