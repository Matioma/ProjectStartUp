using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipView : MonoBehaviour
{
    FleetModel fleetModel;

    [SerializeField]
    ShipActionsView[] views;

    //Dictionary<Type, ShipActionsView> shipType2ViewMap = new Dictionary<Type, ShipActionsView>();

    private void Awake()
    {
        fleetModel = FindObjectOfType<FleetModel>();
        fleetModel.onSelectionChanged += UpdateUI;
    }


    private void Start()
    {
        //shipType2ViewMap[typeof(MainShip)] = GetViewOfType(typeof(MainShipView));



        foreach (var view in views) {
            view.Init(fleetModel);
        }
    }

    void UpdateUI() {
        foreach (var view in views) {
            view.Hide();
        }
        Ship selectedShip = fleetModel.GetSelectedShip();
        if (selectedShip == null) return;

        if (selectedShip.GetType() == typeof(MainShip)){
            GetViewOfType(typeof(MainShipView)).Display();
        }

        if (selectedShip.GetType() == typeof(AttackShip)){
            GetViewOfType(typeof(AttackShipView)).Display();
        }
    }

    ShipActionsView GetViewOfType(Type ViewType) {
        foreach (var view in views)
        {
            if (ViewType == view.GetType()) {
                return view;
            }
        }
        Debug.LogError("The view of this type is undefined");
        return null;
    }

}
