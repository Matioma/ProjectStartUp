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


    private void Awake()
    {
        fleetModel =FindObjectOfType<FleetModel>();
        fleetModel.onFleetDataChanged += UpdateUI;
    }

    void UpdateUI() {
        goldAmount.text = fleetModel.FleetResources.getBalance(ResourceType.Gold).ToString() + " Gold";
        woodAmount.text = fleetModel.FleetResources.getBalance(ResourceType.Wood).ToString() + " Wood";
        orangesAmount.text = fleetModel.FleetResources.getBalance(ResourceType.Oranges).ToString() + " Oranges";
    }


    private void OnDestroy()
    {
        fleetModel.onFleetDataChanged -= UpdateUI;
    }


}
