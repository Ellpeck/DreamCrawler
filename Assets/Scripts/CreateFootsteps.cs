using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFootsteps : MonoBehaviour {

    public Transform[] footstepSpawnPoints;
    public GameObject footstep;
    public float interval;
    public float despawnTime;

    private Vector3 lastPos;
    private float timer;
    private int index;

    private void Update() {
        if (this.transform.position != this.lastPos) {
            this.timer += Time.deltaTime;
            if (this.timer >= this.interval) {
                this.timer = 0;
                var inst = Instantiate(this.footstep, this.footstepSpawnPoints[this.index].position, Quaternion.identity);
                Destroy(inst, this.despawnTime);
                this.index = (this.index + 1) % this.footstepSpawnPoints.Length;
            }
            this.lastPos = this.transform.position;
        }
    }

}