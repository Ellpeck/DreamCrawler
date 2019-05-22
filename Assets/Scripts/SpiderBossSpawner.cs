using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBossSpawner : MonoBehaviour {

    public GameObject spiderBoss;
    public float newZoom;
    public float speed;

    private bool hasEntered;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!this.hasEntered && other.CompareTag("Player")) {
            this.hasEntered = true;
            this.spiderBoss.SetActive(true);
        }
    }

    private void Update() {
        if (this.hasEntered) {
            var cam = MainCamera.Instance.Camera;
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, this.newZoom, this.speed);
        }
    }

}