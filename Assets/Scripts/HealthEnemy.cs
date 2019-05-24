using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class HealthEnemy : MonoBehaviour {

    private static readonly int Hurt = Animator.StringToHash("Hurt");

    public float maxHealth;
    public float health;
    public float damageCooldown;
    public GameObject[] deathObjects;
    public UnityEvent onDeath;
    public bool destroyOnDeath = true;
    public AudioClip hurtSound;
    public AudioClip deathSound;

    private Animator animator;
    private float cooldownTimer;

    private void Start() {
        this.health = this.maxHealth;
        this.animator = this.GetComponent<Animator>();
    }

    private void Update() {
        if (this.cooldownTimer > 0)
            this.cooldownTimer -= Time.deltaTime;
    }

    public void TakeDamage(float amount) {
        if (this.cooldownTimer > 0 || this.health <= 0)
            return;

        this.health = Math.Max(0, this.health - amount);
        this.animator.SetTrigger(Hurt);
        this.cooldownTimer = this.damageCooldown;

        if (this.health <= 0) {
            if (this.destroyOnDeath)
                Destroy(this.gameObject);
            this.onDeath.Invoke();

            foreach (var obj in this.deathObjects)
                Instantiate(obj, this.transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));

            if (this.deathSound)
                AudioSource.PlayClipAtPoint(this.deathSound, this.transform.position);
        }

        if (this.health <= 0 || this.CompareTag("Player")) {
            MainCamera.Instance.Shake();
        }
        if (this.hurtSound)
            AudioSource.PlayClipAtPoint(this.hurtSound, this.transform.position);
    }

    public void Heal(float amount) {
        this.health = Math.Min(this.maxHealth, this.health + amount);
    }

}