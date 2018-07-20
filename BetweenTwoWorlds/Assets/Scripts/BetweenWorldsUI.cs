using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetweenWorldsUI : MonoBehaviour {

    [SerializeField]
    RawImage nixieSequence;

    BetweenWorlds betweenWorlds;

    public delegate void BetweenWorldsDelegate();
    public static event BetweenWorldsDelegate betweenWorldsDelegate;

    void Start () {
        enabled = false;
        betweenWorlds = GameObject.FindGameObjectWithTag("Player").GetComponent<BetweenWorlds>();
        nixieSequence.gameObject.SetActive(false);
    }
	
	public void OnPresentClick() {
        if (betweenWorlds.ToPresent()) {
            StartCoroutine(Transition());
        }
    }

    public void OnFutureClick() {
        if (betweenWorlds.ToFuture()) {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition() {
        betweenWorldsDelegate();
        betweenWorlds.Usable = false;
        nixieSequence.gameObject.SetActive(true);
        int count = 20;
        Color BAlpha = Color.white;
        for (int i = 0; i < count; i++) {
            float wh = Random.Range(1.0f, 4.0f);
            float xy = Random.Range(0.0f, 3.0f);
            nixieSequence.uvRect = new Rect(xy, xy, wh, wh);
            yield return new WaitForSeconds(0.05f);
        }
        nixieSequence.gameObject.SetActive(false);
        betweenWorlds.Usable = true;
    }
}
