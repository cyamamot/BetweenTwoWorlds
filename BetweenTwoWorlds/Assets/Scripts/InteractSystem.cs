using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractSystem : MonoBehaviour {

    [SerializeField]
    float interactDistance;

    bool usable;

	void Awake() {
        enabled = false;
        usable = true;
	}

    public void InteractWithInteractable() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, ~0, QueryTriggerInteraction.Ignore)) {
            Interactable interactable = hit.transform.GetComponent<Interactable>();
            if (interactable != null) {
                interactable.InteractedWith();
            }
        }
    }
}
