using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideshowQuestObjective : QuestObjective {

    [SerializeField]
    SlideshowUI slideshowUI;
    [SerializeField]
    SlideshowFrames[] slideshow;

    void Awake() {
        enabled = false;
    }

    public override DialogueArray[] CheckObjective() {
        if (QuestManager.instance != null && QuestManager.instance.CheckQuestObjective(questKey.ToString(), questID, true)) {
            slideshowUI.BeginSlideshow(slideshow, text);
            return null;
        }
        return null;
    }
}
