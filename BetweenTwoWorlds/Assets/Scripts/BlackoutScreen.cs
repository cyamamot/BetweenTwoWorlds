using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackoutScreen : MonoBehaviour {

    Image background;

    void Awake() {
        enabled = false;
        background = GetComponent<Image>();
        MakeDark(false);
        SceneChangeInteractable.sceneChangeDelegate += MakeDark;
    }

    public void MakeDark(bool darken) {
        if (darken) {
            gameObject.SetActive(true);
            StartCoroutine(Darken());
        } else {
            StartCoroutine(Lighten());
        }
    }

    IEnumerator Darken() {
        float ratio;
        Color black = Color.black;
        for (int i = 0; i <= 10; i++) {
            ratio = i / 10.0f;
            black.a = ratio;
            yield return background.color = black;
        }
    }

    IEnumerator Lighten() {
        float ratio;
        Color black = Color.black;
        for (int i = 10; i >= 0; i--) {
            ratio = i / 10.0f;
            black.a = ratio;
            yield return background.color = black;
        }
        gameObject.SetActive(false);
    }
}
