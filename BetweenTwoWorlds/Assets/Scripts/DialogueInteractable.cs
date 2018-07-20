using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInteractable : Interactable {

    [SerializeField]
    DialogueArray[] dialogue;

    QuestObjective[] objectives;

    public delegate void InteractionDelegate(DialogueArray[] d);
    public static event InteractionDelegate interactionDelegate;

    void Awake() {
        enabled = false;
        objectives = GetComponents<QuestObjective>();
    }

    public override void InteractedWith() {
        DialogueArray[] questText;
        if (objectives != null && objectives.Length > 0) {
            foreach (QuestObjective obj in objectives) {
                questText = obj.CheckObjective();
                if (questText != null) { 
                    DisplayInteraction(questText);
                    return;
                }
            }
        }
        DisplayInteraction(dialogue);
    }

    public void DisplayInteraction(DialogueArray[] d) {
        interactionDelegate(d);
    }
}
