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
    GameObject map;
    [SerializeField]
    GameObject city;

    [SerializeField]
    GameObject battleScene;


    [SerializeField]
    GameStatusState battleState;
    [SerializeField]
    GameStatusState cityState;
    [SerializeField]
    GameStatusState mapState;

    void Start()
    {
        city.SetActive(true);
        map.SetActive(false);
    }

    public void SwitchGameState() {
        city.SetActive(!city.activeSelf);
        map.SetActive(!map.activeSelf);    
    }

    public void OpenScene(GameState state) {
        battleState?.DisableState();
        cityState?.DisableState();
        mapState?.DisableState();




        //if (map != null) map.SetActive(false);
        //if (city != null) city.SetActive(false);
        //if(battleScene != null) battleScene.SetActive(false);

        switch (state){
            case GameState.Map:
                //map.SetActive(true);
                mapState.ActivateState();
                break;
            case GameState.City:
                //city.SetActive(true);
                cityState.ActivateState();
                break;
            case GameState.Battle:
                //battleScene.SetActive(true);
                battleState.ActivateState();
                break;
            default:
                Debug.Log("Unkown state");
                break;
        }
    }
}
