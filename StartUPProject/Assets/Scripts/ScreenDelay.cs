using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenDelay : MonoBehaviour
{
    [SerializeField]
    GameObject victoryScreen;

    [SerializeField]
    UnityEvent onVictory;

    [SerializeField]
    float timeToShowVictoryScreen;
    float timer;

    bool timeElapsed;

    void Start()
    {
        timer = timeToShowVictoryScreen;
    }

    public void StartTimer() {
        timer = timeToShowVictoryScreen;
        timeElapsed = false;
    }

    public void ResetVictoryScreen()
    {
        victoryScreen.SetActive(false);
        StartTimer();
    }

    private void OnEnable()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(!timeElapsed && timer <= 0)
        {
            DisplayVictoryScreen();
        }
    }
    void DisplayVictoryScreen() {
        victoryScreen.SetActive(true);
        onVictory?.Invoke();
    }
}
