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
        if (Selected) return;
        
        //ParentDeselectallShips();
        onSelect?.Invoke();
        Selected = true;
    }

    public void DeselectShip() {
        if (!Selected) return;

        onDeselect?.Invoke();
        Selected = false;
    }


    public void ParentDeselectallShips()
    {
        GetComponentInParent<WorldModel>().DeselectAllShips();
    }
}
