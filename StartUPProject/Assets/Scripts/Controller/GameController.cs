using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameContext gameContext;

    private void Awake()
    {
        gameContext = FindObjectOfType<GameContext>();
        if (gameContext == null) {
            Debug.Log("Game context is not present in the game");
        }
    }

    public void SwitchGameState() {
        gameContext.SwitchGameState();
    }
}
