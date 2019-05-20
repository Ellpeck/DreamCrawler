using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemiesToSpawn;
    public GameObject drop;

    private List<Transform> positions;
    private List<GameObject> spawnedEnemies;

    private void Start() {
        this.positions = new List<Transform>();
        for (var i = 0; i < this.transform.childCount; i++) {
            this.positions.Add(this.transform.GetChild(i));
        }
        this.spawnedEnemies = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player") && this.positions.Count > 0) {
            foreach (var pos in this.positions) {
                var enemy = this.enemiesToSpawn[Random.Range(0, this.enemiesToSpawn.Length)];
                this.spawnedEnemies.Add(Instantiate(enemy, pos.position, pos.rotation, this.transform.parent));
                Destroy(pos.gameObject);
            }
            this.positions.Clear();
        }
    }

    private void Update() {
        if (this.spawnedEnemies.Count > 0 && this.drop) {
            foreach (var enemy in this.spawnedEnemies) {
                if (enemy)
                    return;
            }
            Instantiate(this.drop, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}