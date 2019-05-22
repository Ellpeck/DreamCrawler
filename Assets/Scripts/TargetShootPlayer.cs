using JetBrains.Annotations;
using UnityEngine;

public class TargetShootPlayer : MonoBehaviour {

    private static readonly int Walking = Animator.StringToHash("Walking");
    private static readonly int Shooting = Animator.StringToHash("Shooting");

    public float speed;
    public float minDistance;
    public Transform projectileSpawn;
    public GameObject projectile;
    public float cooldownTime;

    private Transform player;
    private Rigidbody2D body;
    private Animator anim;
    private float cooldown;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        this.anim = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        var position = this.body.position;
        var playerPos = this.player.position;
        if (Vector2.Distance(position, playerPos) > this.minDistance) {
            this.body.MovePosition(Vector2.MoveTowards(position, playerPos, this.speed));
            this.anim.SetBool(Walking, true);
        } else {
            this.anim.SetBool(Walking, false);

            this.projectileSpawn.rotation = Quaternion.FromToRotation(Vector3.left, new Vector2(position.x - playerPos.x, position.y - playerPos.y));
            if (this.cooldown <= 0) {
                this.anim.SetTrigger(Shooting);
                this.cooldown = this.cooldownTime;
            } else {
                this.cooldown -= Time.deltaTime;
            }
        }
    }

    [UsedImplicitly]
    public void Shoot() {
        Instantiate(this.projectile, this.projectileSpawn.position, this.projectileSpawn.rotation);
    }

    [UsedImplicitly]
    public void Enable() {
        this.enabled = true;
    }

}