using System.Collections;
using System.Collections.Generic;

using TMPro;
using UnityEngine;

public class CityView : MonoBehaviour
{
    FleetModel fleetModel;

    [SerializeField]
    TextMeshProUGUI goldAmount;
    [SerializeField]
    TextMeshProUGUI woodAmount;
    [SerializeField]
    TextMeshProUGUI orangesAmount;

    [SerializeField]
    TextMeshProUGUI attackShipsCount;

    [SerializeField]
    TextMeshProUGUI defenceShipsCount;

    private void Awake()
    {
        fleetModel =FindObjectOfType<FleetModel>();
        fleetModel.onFleetDataChanged += UpdateUI;
    }

    void UpdateUI() {
        goldAmount.text = fleetModel.FleetResources.GetBalance(ResourceType.Gold) +"/" + fleetModel.FleetResources.GetStorageCap(ResourceType.Gold) + " Gold";
        woodAmount.text = fleetModel.FleetResources.GetBalance(ResourceType.Wood) + "/" + fleetModel.FleetResources.GetStorageCap(ResourceType.Wood) + " Wood";
        orangesAmount.text = fleetModel.FleetResources.GetBalance(ResourceType.Oranges) + "/" + fleetModel.FleetResources.GetStorageCap(ResourceType.Oranges) + " Oranges";

        attackShipsCount.text = fleetModel.GetShipsCount(typeof(AttackShip)) + "/"  + fleetModel.FleetData.MaxAttackShips + " AttackShips";
        defenceShipsCount.text = fleetModel.GetShipsCount(typeof(DefenceShip)) + "/"+ fleetModel.FleetData.MaxDefenceShips + " DefenceShips";
    }

    private void OnDestroy()
    {
        fleetModel.onFleetDataChanged -= UpdateUI;
    }


}
