using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameContext context;

    public void Awake()
    {
        context = FindObjectOfType<GameContext>();

    }

    public void OpenScene(string state) {
        if (Enum.TryParse(state, out GameState stateEnum)){
            context.OpenScene(stateEnum);
        }
    }
}
