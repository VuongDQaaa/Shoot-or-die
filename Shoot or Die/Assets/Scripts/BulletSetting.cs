using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSetting : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);
    }
}
