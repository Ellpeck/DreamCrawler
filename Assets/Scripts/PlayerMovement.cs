using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private static readonly int Walking = Animator.StringToHash("Walking");

    public float moveSpeed;
    public GameObject weapon;
    public GameObject projectile;
    public Transform projectileSpawn;

    private Camera mainCamera;
    private Animator animator;
    private Rigidbody2D body;

    private float horizontal;
    private float vertical;

    private void Start() {
        this.mainCamera = Camera.main;
        this.animator = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.vertical = Input.GetAxisRaw("Vertical");

        var mouse = this.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        var weaponTrans = this.weapon.transform;
        var weaponPos = weaponTrans.position;
        weaponTrans.up = -new Vector3(mouse.x - weaponPos.x, mouse.y - weaponPos.y);

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(this.projectile, this.projectileSpawn.position, this.projectileSpawn.rotation);
        }
    }

    private void FixedUpdate() {
        var motion = new Vector2(this.horizontal, this.vertical) * this.moveSpeed;
        this.body.MovePosition(this.body.position + motion);

        this.animator.SetBool(Walking, motion.x != 0 || motion.y != 0);
    }

}