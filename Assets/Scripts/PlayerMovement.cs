using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    private static readonly int Walking = Animator.StringToHash("Walking");

    public float moveSpeed;
    public GameObject weapon;
    public Transform projectileSpawn;
    public WeaponType defaultWeaponType;
    public WeaponType currWeaponType;

    private Animator animator;
    private Rigidbody2D body;

    private float horizontal;
    private float vertical;
    private float cooldown;
    private bool isDead;
    private bool weaponFacingLeft;

    private void Start() {
        this.animator = this.GetComponent<Animator>();
        this.body = this.GetComponent<Rigidbody2D>();
        this.currWeaponType = Instantiate(this.defaultWeaponType);

        var checkpoint = CheckpointManager.Instance.currentCheckpoint;
        if (checkpoint != Vector2.zero)
            this.transform.position = checkpoint;
    }

    private void Update() {
        if (this.isDead)
            return;
        this.horizontal = Input.GetAxisRaw("Horizontal");
        this.vertical = Input.GetAxisRaw("Vertical");

        var mouse = MainCamera.Instance.Camera.ScreenToWorldPoint(Input.mousePosition);
        var weaponTrans = this.weapon.transform;
        var weaponPos = weaponTrans.position;
        weaponTrans.up = -new Vector3(mouse.x - weaponPos.x, mouse.y - weaponPos.y);
        if (weaponTrans.up.x > 0)
            weaponTrans.Rotate(0, 180, 0);

        if (this.cooldown <= 0) {
            if (Input.GetMouseButton(0)) {
                Instantiate(this.currWeaponType.projectile, this.projectileSpawn.position, this.projectileSpawn.rotation);
                this.cooldown = this.currWeaponType.cooldown;

                this.currWeaponType.uses--;
                if (this.currWeaponType.uses <= 0) {
                    this.currWeaponType = Instantiate(this.defaultWeaponType);
                }
            }
        } else {
            this.cooldown -= Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        if (this.isDead) {
            this.animator.SetBool(Walking, false);
            return;
        }

        var motion = new Vector2(this.horizontal, this.vertical) * this.moveSpeed;
        this.body.MovePosition(this.body.position + motion);

        this.animator.SetBool(Walking, motion.x != 0 || motion.y != 0);
    }

    [UsedImplicitly]
    public void OnDeath() {
        if (this.isDead)
            return;
        this.isDead = true;
        foreach (var rend in this.GetComponentsInChildren<SpriteRenderer>())
            rend.enabled = false;
        this.StartCoroutine(RestartLevel());
    }

    private static IEnumerator RestartLevel() {
        Fade.Instance.FadeOut();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}