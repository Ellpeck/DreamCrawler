using System;
using UnityEngine;

public class FakeWall : MonoBehaviour {

    private static readonly int Disappear = Animator.StringToHash("Disappear");
    private Animator animator;

    private void Start() {
        this.animator = this.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            this.animator.SetTrigger(Disappear);
    }

}