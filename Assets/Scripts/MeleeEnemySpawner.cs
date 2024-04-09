using System.Collections;
using UnityEngine;

public class MeleeEnemySpawner : MonoBehaviour
{
    public static MeleeEnemySpawner instance;
    [SerializeField] private GameObject meleeEnemy;
    public int xPos_1, xPos_2, zPos;
    public bool spawn;
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Awake()
    {
        MakeInstance();
    }
    private void Start()
    {
        spawn = true;
    }
    private void Update()
    {
        if (PlayerController.instance.ammored == true
        && GamePlayController.instance.killedEnemyStage1 < 5
        && spawn == true)
        {
            StartCoroutine(EnemyDrop());
        }
    }
    IEnumerator EnemyDrop()
    {
        spawn = false;
        xPos_1 = Random.Range(-37, -25);
        xPos_2 = Random.Range(20, 24);
        int[] randomX = { xPos_1, xPos_2 };
        zPos = Random.Range(90, 118);
        Instantiate(meleeEnemy, new Vector3(randomX[Random.Range(0, 2)], 12, zPos), Quaternion.identity);
        yield return new WaitForSeconds(3);
    }
}
