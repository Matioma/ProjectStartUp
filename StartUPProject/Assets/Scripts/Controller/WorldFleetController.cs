using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldFleetController : MonoBehaviour
{
    public void AttackShip() {
        FindObjectOfType<GameContext>().OpenScene(GameState.Battle);
    }
}
