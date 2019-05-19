using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour {

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private HealthEnemy player;
    private float lastHealth;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthEnemy>();
    }

    private void Update() {
        if (this.player.health != this.lastHealth) {
            this.lastHealth = this.player.health;

            for (var i = 0; i < this.hearts.Length; i++) {
                this.hearts[i].sprite = this.lastHealth > i ? this.fullHeart : this.emptyHeart;
            }
        }
    }

}