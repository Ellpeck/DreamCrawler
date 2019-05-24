using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBossSpawner : MonoBehaviour {

    public GameObject spiderBoss;
    public float newZoom;
    public float speed;
    public GameObject[] walls;
    public AudioClip spawnSound;

    private bool hasEntered;

    private void OnTriggerEnter2D(Collider2D other) {
        if (!this.hasEntered && other.CompareTag("Player")) {
            this.hasEntered = true;
            this.spiderBoss.SetActive(true);
            foreach (var wall in this.walls)
                wall.SetActive(true);

            AudioSource.PlayClipAtPoint(this.spawnSound, this.spiderBoss.transform.position);
        }
    }

    private void Update() {
        if (this.hasEntered) {
            var cam = MainCamera.Instance.Camera;
            cam.orthographicSize = Mathf.MoveTowards(cam.orthographicSize, this.newZoom, this.speed);
        }
    }

}