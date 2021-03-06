using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStatusState : MonoBehaviour
{
    public UnityEvent onStateActivate;
    public UnityEvent onDisableState;

    bool isActiveState=false;

    private void Start()
    {
        isActiveState = gameObject.activeSelf;
    }

    public void ActivateState() {
        if (isActiveState) return;

        onStateActivate?.Invoke();

        Debug.Log(transform.name + " Activated");
        isActiveState = true;
    }

    public void DisableState() {
        if (!isActiveState) return;

        onDisableState?.Invoke();
        isActiveState = false;
    }
}
