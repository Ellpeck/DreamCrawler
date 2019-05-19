using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    private static readonly int In = Animator.StringToHash("FadeIn");
    private static readonly int Out = Animator.StringToHash("FadeOut");

    public static Fade Instance { get; private set; }
    private Animator anim;

    private void Start() {
        this.anim = this.GetComponent<Animator>();
        Instance = this;
    }

    public void FadeOut() {
        this.anim.SetTrigger(Out);
    }

    public void FadeIn() {
        this.anim.SetTrigger(In);
    }

}