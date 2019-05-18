using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float yOffset;
    private GameObject player;

    private void Start() {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        var playerPos = this.player.transform.position;
        var trans = this.transform;
        trans.position = new Vector3(playerPos.x, playerPos.y + this.yOffset, trans.position.z);
    }

}