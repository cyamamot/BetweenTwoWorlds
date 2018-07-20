using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    float initialDistance;
	GameObject player;
    Kino.AnalogGlitch glitch;

	void Awake() {
        initialDistance = Camera.main.orthographicSize;
		player = GameObject.FindGameObjectWithTag ("Player");
        if (player != null) {
            transform.position = player.transform.position;
        }
        glitch = GetComponentInChildren<Kino.AnalogGlitch>();
        BetweenWorldsUI.betweenWorldsDelegate += Glitch;
    }
		
	void LateUpdate () {
		if (player != null) {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 0.2f);
		}
	}

    public void Glitch() {
        StartCoroutine(GlitchEffect());
    }

    IEnumerator GlitchEffect() {
        glitch.scanLineJitter = 0.75f;
        glitch.colorDrift = 0.75f;
        glitch.verticalJump = 0.2f;
        glitch.horizontalShake = 0.5f;
        yield return new WaitForSecondsRealtime(1.0f);
        glitch.scanLineJitter = 0.0f;
        glitch.colorDrift = 0.0f;
        glitch.verticalJump = 0.0f;
        glitch.horizontalShake = 0.0f;
    }
}
