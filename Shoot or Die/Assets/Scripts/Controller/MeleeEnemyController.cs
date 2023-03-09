using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    public float speed;
    public float health = 40f;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        rb.AddForce(speed * Time.deltaTime * transform.forward, ForceMode.Impulse);
        EnemyDie();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            health -= PlayerController.instance.currentDamage;
        }
    }

    void EnemyDie()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            MeleeEnemySpawner.instance.spawn = true;
            GamePlayController.instance.killedEnemyStage1++;
        }
    }
}
