using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldFleetBehaviour : MonoBehaviour
{
    [SerializeField]
    public WorldFleetData worldFleetData;

    public bool Selected=false;

    public UnityEvent onSelect;
    public UnityEvent onDeselect;

    public void Init(WorldFleetData data) {
        worldFleetData = data;
    }



    public void SelectingShip() {
        if (worldFleetData.isPlayer) return;
        if (Selected) return;
        
        ParentDeselectAllShips();
        onSelect?.Invoke();
        Selected = true;
    }

    public void DeselectShip() {
        if (worldFleetData.isPlayer) return;
        if (!Selected) return;

        onDeselect?.Invoke();
        Selected = false;
    }


    public void ParentDeselectAllShips()
    {
        GetComponentInParent<WorldModel>().DeselectAllShips();
    }

    public void AttackShip() {
    }
}
