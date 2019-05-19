using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private static readonly int Walking = Animator.StringToHash("Walking");

    public float moveSpeed;
    public GameObject weapon;
    public Transform projectileSpawn;
    public GameObject projectile;
    public float weaponCooldown;

    private Camera mainCamera;
    private Animator animator;
    private Rigidbody2D body;

    private float horizontal;
    private float vertical;
    private float cooldown;

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

        if (this.cooldown <= 0) {
            if (Input.GetMouseButton(0)) {
                Instantiate(this.projectile, this.projectileSpawn.position, this.projectileSpawn.rotation);
                this.cooldown = this.weaponCooldown;
            }
        } else {
            this.cooldown -= Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        var motion = new Vector2(this.horizontal, this.vertical) * this.moveSpeed;
        this.body.MovePosition(this.body.position + motion);

        this.animator.SetBool(Walking, motion.x != 0 || motion.y != 0);
    }

    [UsedImplicitly]
    public void OnDeath() {
        Debug.Log("Ded");
    }
}