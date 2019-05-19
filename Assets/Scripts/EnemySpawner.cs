using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemiesToSpawn;
    private List<Transform> positions;

    private void Start() {
        this.positions = new List<Transform>();
        for (var i = 0; i < this.transform.childCount; i++) {
            this.positions.Add(this.transform.GetChild(i));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            foreach (var pos in this.positions) {
                var enemy = this.enemiesToSpawn[Random.Range(0, this.enemiesToSpawn.Length)];
                Instantiate(enemy, pos.position, pos.rotation, this.transform.parent);
                Destroy(pos.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

}