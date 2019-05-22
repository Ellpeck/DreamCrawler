using JetBrains.Annotations;
using UnityEngine;

public class TargetPlayer : MonoBehaviour {

    private static readonly int Walking = Animator.StringToHash("Walking");

    public float speed;
    public float damageDealt;

    private Transform player;
    private Rigidbody2D body;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.body = this.GetComponent<Rigidbody2D>();
        this.GetComponent<Animator>().SetBool(Walking, true);
    }

    private void FixedUpdate() {
        this.body.MovePosition(Vector2.MoveTowards(this.body.position, this.player.position, this.speed));
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (this.damageDealt > 0 && other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<HealthEnemy>().TakeDamage(this.damageDealt);
        }
    }

    [UsedImplicitly]
    public void Enable() {
        this.enabled = true;
    }

}