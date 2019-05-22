using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpiderBoss : MonoBehaviour {

    private static readonly int Walking = Animator.StringToHash("Walking");

    public float speed;
    public GameObject spit;
    public float spitDelay;
    public float spitInbetweenAngle;
    public float spitDelayDecrease;
    public float spitAngleDecrease;
    public float phaseTwoHealth;
    public GameObject[] spawnedEnemies;
    public Transform[] spawnPositions;
    public float spawnDelay;
    public float spawnDelayDecrease;
    public float damageOnContact;
    public Slider healthBar;

    private Transform player;
    private Rigidbody2D body;
    private Animator animator;
    private HealthEnemy health;
    private float spitTimer;
    private float spawnTimer;
    private float lastHealth;
    private bool phaseTwo;
    private bool hasSpawned;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.body = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.health = this.GetComponent<HealthEnemy>();
    }

    private void FixedUpdate() {
        if (!this.hasSpawned)
            return;

        var pos = this.body.position;
        var goal = new Vector2(this.player.position.x, pos.y);
        if (Vector2.Distance(goal, pos) >= 1) {
            this.body.MovePosition(Vector2.MoveTowards(pos, goal, this.speed));
            this.animator.SetBool(Walking, true);
        } else {
            this.animator.SetBool(Walking, false);
        }
    }

    private void Update() {
        if (this.lastHealth != this.health.health) {
            for (var i = 0; i < this.lastHealth - this.health.health; i++) {
                this.spitDelay -= this.spitDelayDecrease;
                this.spitInbetweenAngle -= this.spitAngleDecrease;
                if (this.phaseTwo)
                    this.spawnDelay -= this.spawnDelayDecrease;
            }

            if (!this.phaseTwo && this.health.health <= this.phaseTwoHealth)
                this.phaseTwo = true;

            this.lastHealth = this.health.health;
        }
        this.healthBar.value = this.health.health / this.health.maxHealth;

        if (!this.hasSpawned)
            return;

        if (this.spitTimer <= 0) {
            this.spitTimer = this.spitDelay;

            for (float i = 180; i <= 360; i += Random.Range(this.spitInbetweenAngle / 2, this.spitInbetweenAngle)) {
                Instantiate(this.spit, this.transform.position, Quaternion.Euler(0, 0, i));
            }
        } else {
            this.spitTimer -= Time.deltaTime;
        }

        if (this.phaseTwo) {
            if (this.spawnTimer <= 0) {
                this.spawnTimer = this.spawnDelay;

                var point = this.spawnPositions[Random.Range(0, this.spawnPositions.Length)];
                var enemy = this.spawnedEnemies[Random.Range(0, this.spawnedEnemies.Length)];
                Instantiate(enemy, point.position, Quaternion.identity);
            } else {
                this.spawnTimer -= Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (this.damageOnContact > 0 && other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<HealthEnemy>().TakeDamage(this.damageOnContact);
        }
    }

    [UsedImplicitly]
    public void OnSpawn() {
        this.hasSpawned = true;
        this.lastHealth = this.health.health;
        this.healthBar.transform.parent.gameObject.SetActive(true);
    }

    public void OnDeath() {
    }

}