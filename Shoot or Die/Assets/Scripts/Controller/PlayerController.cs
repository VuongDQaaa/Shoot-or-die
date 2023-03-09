using UnityEngine;

public class PlayerController : MonoBehaviour, IHealthPoint
{
    public static PlayerController instance;
    [SerializeField] private GameObject weapon;
    [SerializeField] private GameObject pickUpWeapon;
    [SerializeField] private AudioSource reloadSound;
    [SerializeField] private GameObject ammoObject;
    [SerializeField] private GameObject stage2, stage3, key;
    [SerializeField] GamePlayController gamePlayController;
    [SerializeField] GunData gunData;
    [Header("Movement")]
    private float moveSpeed;
    public float goundDrag;
    public float jumpForce;
    private float jumpCooldown;
    public float airMultiplier;
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Gound Check")]
    private bool grounded;
    public Transform orentation;
    [Header("Movement")]
    private float horizontalInput;
    private float verticalInput;
    public Vector3 movement;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] Transform Orientation;
    public float sensitiveX;
    public float sensitiveY;
    private float xRotation;
    private float yRotation;
    [Header("Character status")]
    public int HealthPoint = 100;
    public int damage = 0;
    private int bootsDamage;
    public int currentDamage;
    public bool ammored;
    public bool haveKey;
    public bool isFrozen;
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        MakeInstance();
        isFrozen = false;
        ammored = false;
        haveKey = false;
        bootsDamage = 0;
        playerRigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFrozen == true)
        {
            movement = new Vector3(0, 0, 0);
            moveSpeed = 0;
        }
        else
        {
            moveSpeed = 400;
            MovementInput();
        }
        SpeedControl();
        PlayerRotation();
        SetFree();
        currentDamage = damage + bootsDamage;
        // handle drag
        if (grounded)
        {
            playerRigidbody.drag = goundDrag;
        }
        else
        {
            playerRigidbody.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovementInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //When to jump
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            grounded = false;
            Jump();
        }
    }

    private void MovePlayer()
    {
        //Calculate movement direction
        movement = orentation.forward * verticalInput + orentation.right * horizontalInput;
        //on ground
        if (grounded)
        {
            playerRigidbody.AddForce(movement.normalized * moveSpeed * 10f, ForceMode.Force);
        }

        //in air
        else if (!grounded)
        {
            playerRigidbody.AddForce(movement.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void PlayerRotation()
    {
        //get mouse input
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitiveX;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitiveY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Rotate cam and rotation
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        Orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            playerRigidbody.velocity = new Vector3(limitedVel.x, playerRigidbody.velocity.y, limitedVel.z);
        }
    }
    private void Jump()
    {
        //reset y velocity
        playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0f, playerRigidbody.velocity.y);
        playerRigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision target)
    {
        if (target.gameObject.CompareTag("Floor"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter(Collider target)
    {
        if (target.CompareTag("Weapon"))
        {
            isFrozen = true;
            ammored = true;
            ammoObject.SetActive(true);
            damage = gunData.damage;
            reloadSound.enabled = true;
            weapon.SetActive(true);
            Destroy(pickUpWeapon);
        }
        if (target.CompareTag("Stage2"))
        {
            Destroy(stage2);
            bootsDamage = 5;
        }
        if (target.CompareTag("Stage3"))
        {
            Destroy(stage3);
            gamePlayController.stage3 = true;
            bootsDamage = bootsDamage + 10;
        }
        if (target.CompareTag("Key"))
        {       
            haveKey = true;
            Destroy(key);
        }
        if(target.CompareTag("Enemy"))
        {
            HealthPoint = HealthPoint - 20  ;  
        }
        if(target.CompareTag("Bullet"))
        {
            HealthPoint = HealthPoint - 25;
        }
        if(target.CompareTag("Phase1"))
        {
            GamePlayController.instance.phase1 = true;
        }
        if(target.CompareTag("Phase2"))
        {
            GamePlayController.instance.phase2 = true;
        }
        if(target.CompareTag("BossBullet"))
        {
            HealthPoint = HealthPoint - 40;
        }
        if(target.CompareTag("BossSword"))
        {
            HealthPoint = HealthPoint - 80;
        }
    }

    public int HP()
    {
        return this.HealthPoint;
    }

    private void SetFree()
    {
        if(gamePlayController.killedEnemyStage1 == 5)
        {
            isFrozen = false;
        }
    }
}
