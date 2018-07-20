using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSpace : MonoBehaviour {

    SphereCollider space;
    InfoSprite infoSprite;

    void Awake() {
        enabled = false;
        space = GetComponent<SphereCollider>();
        infoSprite = GetComponentInChildren<InfoSprite>();
    }

    void OnTriggerEnter(Collider other) {
        infoSprite.ShowInfo();
    }

    void OnTriggerExit(Collider other) {
        infoSprite.HideInfo();
    }
}
