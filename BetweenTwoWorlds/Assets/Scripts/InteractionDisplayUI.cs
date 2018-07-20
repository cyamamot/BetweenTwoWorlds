using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionDisplayUI : MonoBehaviour {

    [SerializeField]
    Image textImage;

    Text textBox;
    DialogueArray[] dialogue;
    int currTextIndex;
    bool displayingText;
    Color imageColor;

    void Awake() {
        enabled = false;
        DialogueInteractable.interactionDelegate += DisplayText;
        textBox = GetComponentInChildren<Text>();
        gameObject.SetActive(false);
        imageColor = Color.white;
    }

	public void DisplayText(DialogueArray[] d) {
        currTextIndex = 0;
        dialogue = d;
        textImage.color = imageColor;
        gameObject.SetActive(true);
        StartCoroutine(TouchWait());
        ShowText();
	}

    public void OnTouch() {
        if (displayingText) {
            currTextIndex++;
            if (currTextIndex < dialogue.Length) {
                ShowText();
            } else {
                displayingText = false;
                currTextIndex = 0;
                textBox.text = "";
                textImage.sprite = null;
                gameObject.SetActive(false);
            }
        }
    }

    void ShowText() {
        textBox.text = dialogue[currTextIndex].text;
        textImage.sprite = dialogue[currTextIndex].sprite;
    }

    IEnumerator TouchWait() {
        yield return new WaitForSecondsRealtime(0.2f);
        displayingText = true;
    }
}
