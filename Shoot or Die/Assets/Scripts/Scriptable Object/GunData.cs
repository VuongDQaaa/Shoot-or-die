using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gun", menuName="Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Infor")]
    public new string name;

    [Header("Gun Setting")]
    public float fireRate = 0.1f;
    public int clipSize = 30;
    public int currentAmmo = 30;
    public int damage;
    public float maxDistance;
}
