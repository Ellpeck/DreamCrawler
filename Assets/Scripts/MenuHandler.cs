using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

    public string playScene;

    public void OnPlayButton() {
        this.StartCoroutine(this.LoadScene());
    }

    private IEnumerator LoadScene() {
        Fade.Instance.FadeOut();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(this.playScene);
    }

}