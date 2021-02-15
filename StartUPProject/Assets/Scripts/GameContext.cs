using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : MonoBehaviour
{
    [SerializeField]
    GameObject map;
    [SerializeField]
    GameObject city;


    private void Start()
    {
        city.SetActive(true);
        map.SetActive(false);
    }


    public void SwitchGameState() {
        city.SetActive(!city.activeSelf);
        map.SetActive(!map.activeSelf);    
    }

}
