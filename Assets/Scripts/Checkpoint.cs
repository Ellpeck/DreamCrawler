﻿using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            CheckpointManager.Instance.currentCheckpoint = this.transform.position;
        }
    }

}