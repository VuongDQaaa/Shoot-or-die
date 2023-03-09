using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject enemy;
    public float bulletSpeed;
    public bool coolDown;

    // Update is called once per frame
    void Update()
    {
        if (!coolDown)
        {
            GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(enemy.transform.forward * bulletSpeed);
            coolDown = true;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2.5f);
        coolDown = false;
    }
}