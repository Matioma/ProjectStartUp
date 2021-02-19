using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { 
    Map,
    City,
    Battle
}

public class GameContext : MonoBehaviour
{


    [SerializeField]
    GameStatusState battleState;
    [SerializeField]
    GameStatusState cityState;
    [SerializeField]
    GameStatusState mapState;

    public void OpenScene(GameState state) {
        battleState?.DisableState();
        cityState?.DisableState();
        mapState?.DisableState();

        switch (state){
            case GameState.Map:
                mapState.ActivateState();
                break;
            case GameState.City:
                cityState.ActivateState();
                break;
            case GameState.Battle:
                battleState.ActivateState();
                break;
            default:
                Debug.Log("Unkown state");
                break;
        }
    }
}
