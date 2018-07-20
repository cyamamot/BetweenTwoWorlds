using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSprite : MonoBehaviour {

    [SerializeField]
    string objName;
    [SerializeField]
    [TextArea]
    string objDescription;

    TextMesh[] textMeshes;
    SpriteMask mask;

    bool showing;

    void Awake() {
        textMeshes = GetComponentsInChildren<TextMesh>();
        mask = GetComponentInChildren<SpriteMask>();
        showing = false;
    }

    public void ShowInfo() {
        StopAllCoroutines();
        StartCoroutine(ShowText(objName, textMeshes[0]));
        StartCoroutine(ShowText(objDescription, textMeshes[1]));
        StartCoroutine(MoveMask(true));
    }

    public void HideInfo() {
        StopAllCoroutines();
        StartCoroutine(HideText(textMeshes[0]));
        StartCoroutine(HideText(textMeshes[1]));
        StartCoroutine(MoveMask(false));
    }

    public void ResetInfo() {
        if (textMeshes != null) {
            StopAllCoroutines();
            showing = false;
            foreach (TextMesh mesh in textMeshes) {
                mesh.text = "";
            }
            mask.transform.localPosition = Vector3.zero;
        }
    }

    void OnDisable() {
        ResetInfo();
    }

    IEnumerator ShowText(string text, TextMesh mesh) {
        mesh.text = "";
        foreach (char c in text) {
            yield return mesh.text += c;
        }
    }

    IEnumerator HideText(TextMesh mesh) {
        while (mesh.text.Length > 0) {
            yield return mesh.text = mesh.text.Substring(0, mesh.text.Length - 1);
        }
    }

    IEnumerator MoveMask(bool show) {
        float currX = mask.transform.localPosition.x;
        Vector3 newPos = new Vector3();
        if (show) {
            while (mask.transform.localPosition.x < 10.0f) {
                currX += 0.25f;
                newPos.Set(currX, 0, 0);
                yield return mask.transform.localPosition = newPos;
            }
        } else {
            while (mask.transform.localPosition.x > 0.0f) {
                currX -= 0.25f;
                newPos.Set(currX, 0, 0);
                yield return mask.transform.localPosition = newPos;
            }
        }
    }
}
