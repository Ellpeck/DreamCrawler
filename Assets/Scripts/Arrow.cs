using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed;
    public float damage;

    private Rigidbody2D body;

    private void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        this.body.velocity = this.transform.right * this.speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        var enemy = other.gameObject.GetComponent<HealthEnemy>();
        if (enemy != null)
            enemy.TakeDamage(this.damage);
        Destroy(this.gameObject);
    }

}