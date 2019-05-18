using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HealthEnemy : MonoBehaviour {

    public float maxHealth;
    public float health;

    private void Start() {
        this.health = this.maxHealth;
    }

    public void TakeDamage(float amount) {
        this.health = Math.Max(0, this.health - amount);
        if (this.health <= 0)
            Destroy(this.gameObject);
    }

}