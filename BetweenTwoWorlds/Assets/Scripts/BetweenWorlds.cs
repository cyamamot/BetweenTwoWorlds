using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BetweenWorlds : MonoBehaviour {

    [SerializeField]
    GameObject worldPresent;
    [SerializeField]
    GameObject worldFuture;

    LeftJoystickPlayerController playerController;
    NavMeshAgent navMeshAgent;
    bool inFuture;
    int presentNavMask;
    int futureNavMask;
    bool usable;

    public bool Usable {
        get { return usable; }
        set {
            usable = value;
            if (usable) {
                playerController.CanMove = true;
            } else {
                playerController.CanMove = false;
            }
        }
    }

	void Awake() {
        playerController = GetComponent<LeftJoystickPlayerController>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        presentNavMask = 1 << NavMesh.GetAreaFromName("Present");
        futureNavMask = 1 << NavMesh.GetAreaFromName("Future");
        navMeshAgent.areaMask = 0;
        navMeshAgent.areaMask += presentNavMask;
        navMeshAgent.areaMask += futureNavMask;
        worldPresent.SetActive(true);
        worldFuture.SetActive(false);
        inFuture = false;
        usable = true;
	}

    public bool ToFuture() {
        if (usable) {
            if (!inFuture) {
                Invoke("SetFuture", 0.3f);
                return true;
            }
        }
        return false;
    }

    public void SetFuture() {
        worldPresent.SetActive(false);
        worldFuture.SetActive(true);
        SetNavFutureMask();
        inFuture = true;
    }

    public bool ToPresent() {
        if (usable) {
            if (inFuture) {
                Invoke("SetPresent", 0.3f);
                return true;
            }
        }
        return false;
    }

    public void SetPresent() {
        worldPresent.SetActive(true);
        worldFuture.SetActive(false);
        SetNavPresentMask();
        inFuture = false;
    }

    void SetNavPresentMask() {
        navMeshAgent.areaMask = 0;
        navMeshAgent.areaMask += presentNavMask;
        navMeshAgent.areaMask += futureNavMask;
    }

    void SetNavFutureMask() {
        navMeshAgent.areaMask = 0;
        navMeshAgent.areaMask += futureNavMask;
    }
}
