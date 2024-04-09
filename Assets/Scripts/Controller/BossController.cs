using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IHealthPoint
{
    public static BossController instance;
    [SerializeField] private Animator anim;
    [SerializeField] Transform sword;
    GameObject player;
    Rigidbody rb;
    public float speed;
    public int health = 1000;
    private float distance;

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
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        rb.AddForce(speed * Time.deltaTime * transform.forward, ForceMode.Impulse);

        //Swing sword when player is near;
        distance = Vector3.Distance(player.transform.position, sword.position);
        if (distance <= 30)
        {
            anim.SetBool("Player", true);
        }
        else
        {
            anim.SetBool("Player", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            health -= PlayerController.instance.currentDamage;
            if (health <= 0)
            {
                GamePlayController.instance.killedBoss = true;
                Destroy(gameObject);
            }
        }
    }

    public int HP()
    {
        return this.health;
    }
}
