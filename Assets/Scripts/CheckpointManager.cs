using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    public static CheckpointManager Instance { get; private set; }
    public Vector2 currentCheckpoint;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

}