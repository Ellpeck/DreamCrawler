using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlayer : MonoBehaviour {

    private static readonly int Walking = Animator.StringToHash("Walking");
    public float speed;
    public bool canLose;

    private Transform player;
    private Animator animator;
    private Rigidbody2D body;

    private bool isActive;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.animator = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (this.isActive) {
            this.body.MovePosition(Vector2.MoveTowards(this.body.position, this.player.position, this.speed));
        }
        this.animator.SetBool(Walking, this.isActive);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            this.isActive = true;
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (this.canLose && other.CompareTag("Player"))
            this.isActive = false;
    }

}