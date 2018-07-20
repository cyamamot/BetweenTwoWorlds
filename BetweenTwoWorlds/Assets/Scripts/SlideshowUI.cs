using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideshowUI : MonoBehaviour {

    BlackoutScreen blackoutScreen;
    int currSlide;
    int currNumToNextFrame;

    void Awake() {
        enabled = false;
    }

    public void BeginSlideshow(SlideshowFrames[] slideshow, DialogueArray[] text) {

    }

    public void OnClick() {

    }
}
