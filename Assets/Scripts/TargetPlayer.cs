using UnityEngine;

public class TargetPlayer : MonoBehaviour {

    public float speed;
    public float damageDealt;

    private Transform player;
    private Rigidbody2D body;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        this.body.MovePosition(Vector2.MoveTowards(this.body.position, this.player.position, this.speed));
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (this.damageDealt > 0 && other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<HealthEnemy>().TakeDamage(this.damageDealt);
        }
    }

}