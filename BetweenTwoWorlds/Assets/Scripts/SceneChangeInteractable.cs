using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeInteractable : Interactable {

    [SerializeField]
    string nextScene;

    bool usable;

    public delegate void SceneChangeDelegate(bool darken);
    public static event SceneChangeDelegate sceneChangeDelegate;

    void Awake() {
        enabled = false;
        usable = true;
    }
	
	public override void InteractedWith() {
        if (usable) {
            usable = false;
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene() {
        sceneChangeDelegate(true);
        yield return new WaitForSecondsRealtime(1.0f);
        SceneManager.LoadScene(nextScene);
    }
}
