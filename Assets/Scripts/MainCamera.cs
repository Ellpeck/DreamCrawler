using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour {

    private static readonly int AnimShake = Animator.StringToHash("Shake");

    public static MainCamera Instance { get; private set; }
    public Camera Camera { get; private set; }
    private Animator animator;

    private void Start() {
        this.animator = this.GetComponent<Animator>();
        this.Camera = this.GetComponent<Camera>();
        Instance = this;
    }

    public void Shake() {
        this.animator.SetTrigger(AnimShake);
    }

}