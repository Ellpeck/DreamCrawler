using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Type", menuName = "Weapon Type")]
public class WeaponType : ScriptableObject {

    public GameObject projectile;
    public int uses;
    public float cooldown;

}