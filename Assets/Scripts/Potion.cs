using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    public float healAmount;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            var enemy = other.GetComponent<HealthEnemy>();
            if (enemy != null && enemy.health < enemy.maxHealth) {
                enemy.Heal(this.healAmount);
                Destroy(this.gameObject);
            }
        }
    }

}