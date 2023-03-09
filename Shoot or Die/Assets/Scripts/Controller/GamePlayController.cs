using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    public bool stage3;
    public bool killedBoss;
    public bool phase1;
    public bool phase2;
    public int killedEnemyStage1;
    public int killedEnemyStage2;
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
        stage3 = false;
        killedEnemyStage2 = 0;
        killedEnemyStage1 = 0;
        killedBoss = false;
        phase1 = false;
        phase2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
