using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour {

    public WeaponType type;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            var player = other.GetComponent<PlayerMovement>();
            if (player != null) {
                player.currWeaponType = Instantiate(this.type);
                Destroy(this.gameObject);
            }
        }
    }

}