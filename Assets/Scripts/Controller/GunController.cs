using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private AudioSource fireSound, reloadSound;
    [SerializeField] GunData gunData;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject muzzle;
    public GameObject bullet;
    public float bulletSpeed;
    [Header("Gun Setting")]
    public bool canShoot;
    public float currentAmmor;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        currentAmmor = gunData.currentAmmo;
    }

    private void Shoot()
    {
        if (Input.GetMouseButton(0) && canShoot && gunData.currentAmmo > 0)
        {
            canShoot = false;
            GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(muzzle.transform.forward * bulletSpeed);
            gunData.currentAmmo--;
            StartCoroutine(ShootGun());
            fireSound.enabled = false;
        }

        if (gunData.currentAmmo == 0 || Input.GetKey(KeyCode.R))
        {
            canShoot = false;
            StartCoroutine(Reload());
            reloadSound.enabled = false;
        }
    }

    IEnumerator ShootGun()
    {
        yield return new WaitForSeconds(gunData.fireRate);
        canShoot = true;
        fireSound.enabled = true;
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        fireSound.enabled = false;
        reloadSound.enabled = true;
        gunData.currentAmmo = gunData.clipSize;
        canShoot = true;
    }
}
