using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    public float healAmount;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            var health = other.GetComponent<HealthEnemy>();
            if (health != null)
                health.Heal(this.healAmount);
            Destroy(this.gameObject);
        }
    }

}