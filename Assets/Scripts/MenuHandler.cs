using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

    public void LoadSceneOnPress(string scene) {
        this.StartCoroutine(LoadScene(scene));
    }

    private static IEnumerator LoadScene(string scene) {
        Fade.Instance.FadeOut();
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(scene);
    }

}